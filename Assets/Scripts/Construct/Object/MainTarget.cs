using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private float hp;
    public float Hp 
    { 
        get 
        { 
            return hp; 
        } 
        set 
        {
            hp = value;
            if (Hp <= 0) GameManager.Instance.BadEnd();

        } 
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }

    public void TakeHit(float damage)
    {
        Hp -= damage;
    }
}
