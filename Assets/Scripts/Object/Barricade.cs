using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IDamagable
{
    public void ObjectTakeHit()
    {
        Debug.Log("�ǹ� ����");
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }
}
