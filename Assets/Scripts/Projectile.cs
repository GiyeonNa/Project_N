using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public ParticleSystem particle;
    
    [SerializeField] private bool isHit;

    private void Awake()
    {
        damage = GetComponentInParent<Enemy>().Damage;
        particle = GetComponent<ParticleSystem>();
    }
    private void OnParticleCollision(GameObject other)
    {
        IDamagable target = other.GetComponent<IDamagable>();
        target?.TakeHit(damage);
    }

    //private void OnParticleTrigger()
    //{
    //    //Triggers 옵션ㅇ ㅣ켜져있어야함
    //    if (isHit) return;
    //    Debug.Log("Particle hit");
    //    isHit = true;
    //    //피해를 주어야함, 어떻게 전달?

    //}

   
}
