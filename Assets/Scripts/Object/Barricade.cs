using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IDamagable
{
    [SerializeField] float hp;

    public void TakeHit(float damage)
    {
        Debug.Log(damage + " ��ŭ ���ظ� ����");
        hp -= damage;
        if (hp <= 0)
        {

            Destroy(gameObject);
        }
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }



  
}
