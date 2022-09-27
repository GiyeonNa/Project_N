using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR : BaseGun
{
    private bool isScope = false;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public GameObject cross;

    public float scopeFOV = 15f;
    private float normalFOV;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Debug.Log("SR in");
        onChangeMag?.Invoke();
    }

    private void Update()
    {
        GunFireRateCale();
        if (Input.GetButtonDown("Fire2"))
        {
            isScope = !isScope;
            animator.SetBool("Scope", isScope);

            if (isScope)
                StartCoroutine(OnScope());
            else
                OnUnscope();
        }
        

    }

    void OnUnscope()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        cross.SetActive(true);
        mainCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScope()
    {
        yield return new WaitForSeconds(0.15f);
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopeFOV;

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        cross.SetActive(false);
    }

    public override IEnumerator Reload()
    {
        isReloading = true;
        animator.SetTrigger("Reload");
        audioSource.clip = reloadSound;
        audioSource.Play();
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        totalMagazine -= (reloadMagazine - curMagazine);
        curMagazine = reloadMagazine;
        
        onChangeMag?.Invoke();
    }
    public override void Shot()
    {
        if (curFireRate > 0) return;
        if (curMagazine == 0) return;
        animator.SetTrigger("Shot");
        curFireRate = gunFireRate;
        curMagazine -= 1;
        onChangeMag?.Invoke();
        audioSource.clip = shotSound;
        audioSource.Play();
        muzzle.Play();

        //단발 연발로 바꾸기
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeHit(damage, hit);

        }

    }

    public void MuzzlePlay()
    {
        muzzle.Play();
    }
}
