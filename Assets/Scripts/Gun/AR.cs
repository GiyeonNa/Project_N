using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : BaseGun
{
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
        curFireRate = gunFireRate;
        curMagazine -= 1;
        Debug.Log("Shot");
    }
}
