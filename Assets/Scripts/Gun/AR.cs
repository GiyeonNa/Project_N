using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : BaseGun
{
    public override void Reload()
    {
        totalMagazine -= (reloadMagazine - curMagazine);
        curMagazine = reloadMagazine;
        
        Debug.Log("tot : " + totalMagazine);
        Debug.Log("cur : " + curMagazine);
        Debug.Log("re : " + reloadMagazine);
    }

    public override void Shot()
    {
        if (this.currentStyle == GunStyles.nonautomatic) Debug.Log("noAuto");
        else Debug.Log("Auto");
        curMagazine -= 1;

        //if (currentStyle == GunStyles.nonautomatic)
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        ShootMethod();
        //    }
        //}
        //if (currentStyle == GunStyles.automatic)
        //{
        //    if (Input.GetButton("Fire1"))
        //    {
        //        ShootMethod();
        //    }
        //}
    }

    
}
