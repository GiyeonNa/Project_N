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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) Destroy(gameObject);
        if (other.gameObject.layer == 6 || other.gameObject.layer == 9)
        {
            IDamagable othertarget = other.GetComponent<IDamagable>();
            othertarget?.TakeHit(damage);
            Debug.Log("Get Hit");
            Destroy(gameObject);
        }

    }

    private void OnParticleTrigger()
    {
        if (isHit) return;
        Debug.Log("Particle hit");
        isHit = true;
        //피해를 주어야함, 어떻게 전달?
    }
}
