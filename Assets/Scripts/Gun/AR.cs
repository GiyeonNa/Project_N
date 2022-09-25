using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR : BaseGun
{
    [SerializeField] private ParticleSystem bulletShells;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GunFireRateCale();
    }

    private void OnEnable()
    {
        onChangeMag?.Invoke();
    }

    public override IEnumerator Reload()
    {
        isReloading = true;
        audioSource.clip = reloadSound;
        audioSource.Play();
        animator.SetTrigger("Reload");
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
        muzzle.Play();
        bulletShells.Play();
        curFireRate = gunFireRate;
        curMagazine -= 1;
        onChangeMag?.Invoke();

        audioSource.clip = shotSound;
        audioSource.Play();

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log(hit.transform.gameObject.name);
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeHit(damage, hit);

        }
    }
}
