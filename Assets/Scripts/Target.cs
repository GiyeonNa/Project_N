using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private float hp = 20f;
    [SerializeField]
    private float destroyTime = 1f;
    [SerializeField]
    private float score = 1f;

    public void TakeHit(float damage, RaycastHit hit)
    {
        hp -= damage;
        Instantiate(particle, hit.point, Quaternion.LookRotation(hit.normal)).transform.parent = this.transform;
        if (hp <= 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }

    
}
