using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IDamagable
{
    [SerializeField] float hp;

    public void TakeHit(float damage)
    {
        Debug.Log(damage + " 만큼 피해를 입음");
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
