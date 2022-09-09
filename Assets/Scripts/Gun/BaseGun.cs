using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseGun : MonoBehaviour
{
    public enum GunStyles { nonautomatic, automatic }
    public GunStyles currentStyle;

    public int totalMagazine;
    public int curMagazine;
    public int reloadMagazine;

    public abstract void Shot();
    public abstract void Reload();
    
}
