using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IDamagable
{
    // target the gun will aim at
    [SerializeField] private Transform go_target;

    // Gameobjects need to control rotation and aiming
    public Transform go_baseRotation;
    public Transform go_GunBody;
    public Transform go_barrel;

    // Gun barrel rotation
    public float barrelRotationSpeed;
    float currentRotationSpeed;

    // Distance the turret can aim and fire from
    public float firingRange;

    // Particle system for the muzzel flash
    public ParticleSystem muzzelFlash;

    // Used to start and stop the turret firing
    bool canFire = false;

    [SerializeField] private LayerMask layerMask;

    Vector3 plusVec = new Vector3(0, 0.5f, 0);

    [SerializeField] private float damage;
    [SerializeField] private float coolDown;
    [SerializeField] private float hp;

    public AudioSource audioSource;
    public AudioClip shotSound;

    Ray ray;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AimAndFire();
        //if (go_target != null) Debug.Log(go_target.transform.position);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position to show the firing range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);

        //Gizmos.color = Color.blue;
        //if(go_target != null)
        //    Gizmos.DrawLine(this.transform.position + plusVec, go_target.transform.position + plusVec);
    }

    

    void AimAndFire()
    {
        Collider[] targets =  Physics.OverlapSphere(this.transform.position, firingRange, layerMask);
        
        if (targets.Length > 0)
        {
            canFire = true;
            go_target = targets[0].transform;
        }
        else
        {
            canFire = false;
            go_target = null;
        }

        // Gun barrel rotation
        go_barrel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);

        // if can fire turret activates
        if (canFire)
        {
            // start rotation
            currentRotationSpeed = barrelRotationSpeed;

            // aim at enemy
            Vector3 baseTargetPostition = new Vector3(go_target.position.x, this.transform.position.y, go_target.position.z);
            Vector3 gunBodyTargetPostition = new Vector3(go_target.position.x, go_target.position.y + 0.5f, go_target.position.z);

            go_baseRotation.transform.LookAt(baseTargetPostition);
            go_GunBody.transform.LookAt(gunBodyTargetPostition);

            // start particle system 
            if (!muzzelFlash.isPlaying)
            {
                muzzelFlash.Play();
                Debug.Log("Start Coroutine");
                StartCoroutine(CoAttack(coolDown));
            }
        }
        else
        {
            // slow down barrel rotation and stop
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, 10 * Time.deltaTime);

            // stop the particle system
            if (muzzelFlash.isPlaying)
            {
                muzzelFlash.Stop();
                StopCoroutine(CoAttack(0));
            }
        }
    }

    IEnumerator CoAttack(float cooldown)
    {
        //go_target.gameObject.GetComponent<Enemy>().TakeHit(damage);
        //Debug.Log(go_target.gameObject.GetComponent<Enemy>().Hp + "남음");

        ray = new Ray(this.transform.position + plusVec, (go_target.transform.position - this.transform.position));
        if (go_target == null) StopCoroutine(CoAttack(0));
        //Ray ray = new Ray(this.transform.position + plusVec, (go_target.transform.position - this.transform.position));
        Debug.DrawRay(this.transform.position + plusVec, go_target.transform.position - this.transform.position, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(name + " get  shot");
            audioSource.clip = shotSound;
            audioSource.Play();
            go_target.GetComponent<IDamagable>().TakeHit(damage, hit);
        }

        //if (Physics.Raycast(this.transform.position, go_target.transform.position, out hit, firingRange))
        //{
        //    Debug.Log(hit.transform.name);
        //    Debug.Log("Get Hit");
        //    //go_target.gameObject.GetComponent<Enemy>().TakeHit(damage);
        //    yield return new WaitForSeconds(cooldown);
        //    StartCoroutine(CoAttack(cooldown));
        //}
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(CoAttack(cooldown));
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }

    public void TakeHit(float damage)
    {
        hp -= damage;
        Debug.Log(damage + "를 입음");
        if (hp <= 0) Destroy(gameObject, 1f);
    }
}
