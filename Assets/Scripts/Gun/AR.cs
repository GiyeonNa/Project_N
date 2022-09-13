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
    }

    private void OnEnable()
    {
        onChangeMag?.Invoke();
    }

    private void Update()
    {
        GunFireRateCale();
    }
    public override void Reload()
    {
        totalMagazine -= (reloadMagazine - curMagazine);
        curMagazine = reloadMagazine;
        animator.SetTrigger("Reload");
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
        //단발 연발로 바꾸기
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log(hit.transform.gameObject.name);
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeHit(damage, hit);

        }
    }
}
