using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour,IPickUpable
{
    [SerializeField] protected Collider pickupRange;

    private void Awake()
    {
        pickupRange = GetComponent<Collider>();
    }

    public virtual void PickUp()
    {
        Destroy(gameObject);
    }
}
