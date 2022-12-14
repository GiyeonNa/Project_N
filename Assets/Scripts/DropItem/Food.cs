using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropItem/Food")]

public class Food : DropItem
{
    public override void Drop(Transform transform)
    {
        Instantiate(prefab, transform.transform.position, transform.transform.rotation);
    }

}
