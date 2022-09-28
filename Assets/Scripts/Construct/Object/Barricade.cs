using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IDamagable
{
    [SerializeField] float hp;
    public float Hp 
    { 
        get 
        { 
            return hp; 
        } 
        set 
        { 
            hp = value;
            if (hp <= 0) Destroy(gameObject);
        } 
    }

    public void TakeHit(float damage)
    {
        Hp -= damage;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }



  
}
