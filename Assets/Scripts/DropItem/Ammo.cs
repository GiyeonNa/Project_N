using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropItem/Ammo")]

public class Ammo : DropItem
{
    public override void Drop(Transform transform)
    {
        Instantiate(prefab, transform.transform.position, transform.transform.rotation);
    }

    
}
