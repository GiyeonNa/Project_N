using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : DropItem
{
    
    public override void PickUp()
    {
        Destroy(gameObject);
    }
}
