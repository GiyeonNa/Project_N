using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IDamagable
{
    public void ObjectTakeHit()
    {
        Debug.Log("건물 맞음");
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }
}
