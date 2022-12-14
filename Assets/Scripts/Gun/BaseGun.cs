using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum GunStyles { nonautomatic, automatic }
public abstract class BaseGun : MonoBehaviour
{
    public GunStyles currentStyle;
    public Camera camera;
    public LayerMask layerMask;
    public Animator animator;
    public RaycastHit hit;
    public ParticleSystem muzzle;

    //sound
    public AudioSource audioSource;
    public AudioClip shotSound;
    public AudioClip reloadSound;

    //public event UnityAction onChangeMag;
    public UnityAction onChangeMag;
    //??ü ??Ÿ??
    public float gunFireRate;
    //??Ÿ?? ?????ð?
    public float curFireRate;

    public float damage;

    public int totalMagazine;
    public int curMagazine;
    public int reloadMagazine;

    public float reloadTime;
    public bool isReloading;

    public abstract void Shot();
    public abstract IEnumerator Reload();

    public virtual void GunFireRateCale()
    {
        if (curFireRate > 0) curFireRate -= Time.deltaTime;
    }
    
}
