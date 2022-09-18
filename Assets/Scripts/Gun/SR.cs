using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR : BaseGun
{
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Debug.Log("SR in");
        onChangeMag?.Invoke();
    }

    private void Update()
    {
        GunFireRateCale();
    }
    public override IEnumerator Reload()
    {
        isReloading = true;
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
        curFireRate = gunFireRate;
        curMagazine -= 1;
        onChangeMag?.Invoke();
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
