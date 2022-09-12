using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR : BaseGun
{
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GunFireRateCale();
    }
    public override void Reload()
    {
        totalMagazine -= (reloadMagazine - curMagazine);
        curMagazine = reloadMagazine;
    }
    public override void Shot()
    {
        if (curFireRate > 0) return;
        animator.SetTrigger("Shot");
        muzzle.Play();
        curFireRate = gunFireRate;
        curMagazine -= 1;
        //단발 연발로 바꾸기
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.transform.gameObject.name);
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeHit(damage);

        }

        Debug.Log("Shot");
    }
}
