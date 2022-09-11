using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunStyles { nonautomatic, automatic }
public abstract class BaseGun : MonoBehaviour
{
    public GunStyles currentStyle;

    //자체 쿨타임
    public float gunFireRate;
    //쿨타임 대기시간
    public float curFireRate;

    public float damage;

    public int totalMagazine;
    public int curMagazine;
    public int reloadMagazine;

    public abstract void Shot();
    public abstract void Reload();

    public virtual void GunFireRateCale()
    {
        if (curFireRate > 0) curFireRate -= Time.deltaTime;
    }
    
}
