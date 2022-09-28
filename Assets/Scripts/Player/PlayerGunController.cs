using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] GunInventory gunInventory;

    private void Awake()
    {
        gunInventory = GetComponentInChildren<GunInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CraftManual.isActivated)
        {
            return;
        }
        if (GameManager.Instance.pause.isShow)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && !gunInventory.curGun.isReloading)
        {
            if (!gunInventory.curGun.isReloading)
            {
                StartCoroutine(gunInventory.curGun.Reload());
            }
            
        }

        if (!gunInventory.curGun.isReloading)
        {
            if (gunInventory.curGun.currentStyle == GunStyles.automatic)
            {
                if (Input.GetButton("Fire1")) gunInventory.curGun.Shot();
            }
            if (gunInventory.curGun.currentStyle == GunStyles.nonautomatic)
            {
                if (Input.GetButtonDown("Fire1")) gunInventory.curGun.Shot();
            }
        }
        
    }
}
