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
    //    //Triggers �ɼǤ� �������־����
    //    if (isHit) return;
    //    Debug.Log("Particle hit");
    //    isHit = true;
    //    //���ظ� �־����, ��� ����?

    //}

   
}
