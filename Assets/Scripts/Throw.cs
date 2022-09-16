using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float damage;
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public Vector3 adjustVec = new Vector3(0, 1, 0);
    //public Transform Projectile;
    private Transform myTransform;
    float target_Distance; 
    void Awake() 
    {
        damage = GetComponentInParent<Enemy>().Damage;
        Target = GetComponentInParent<Enemy>().tempTarget;
        myTransform = transform; 

        target_Distance = Vector3.Distance(this.transform.position, Target.position);
    }
    void Start() { StartCoroutine(SimulateProjectile()); }

    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown? ? ? ?
        //yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.? ? ? ?
        //Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);
        this.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target? ? ? ?
        //float target_Distance = Vector3.Distance(Projectile.position, Target.position);
        //float target_Distance = Vector3.Distance(this.transform.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.? ? ? ?
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X ?Y componenent of the velocity? ? ? ?
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.? ? ? ?
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.? ? ? ?
        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);
        this.transform.rotation = Quaternion.LookRotation(Target.position - this.transform.position);
        float elapse_time = 0;
        while (true)//elapse_time < flightDurationt
        {
            //Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
            this.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) Destroy(gameObject);
        if (other.gameObject.layer == 6 || other.gameObject.layer == 9)
        {
            IDamagable othertarget = other.GetComponent<IDamagable>();
            othertarget?.TakeHit(damage);
            Destroy(gameObject);
        }
        
    }
}