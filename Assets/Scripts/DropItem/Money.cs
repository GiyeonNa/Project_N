using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropItem/Money")]
public class Money : DropItem
{
    public override void Drop(Transform transform)
    {
        //this.amount = Random.Range(25, 150);
        Instantiate(prefab, transform.transform.position, transform.transform.rotation);
    }

    
}
