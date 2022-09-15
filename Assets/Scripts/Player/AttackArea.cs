using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        IDamagable target = other.GetComponent<IDamagable>();
       
    }
}
