using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public GunInventory plyaerGunInventory;
    //[SerializeField] public BaseGun UIcurGun;
    [SerializeField] private TextMeshProUGUI magText;

 
    private void Start()
    {
        //UIcurGun = plyaerGunInventory.curGun;
        //UIcurGun.onChangeMag += OnChangePlayerMag;
        plyaerGunInventory.curGun.onChangeMag += OnChangePlayerMag;
        
        plyaerGunInventory.curGun.onChangeMag?.Invoke();
    }

    private void Update()
    {
        if(plyaerGunInventory.curGun.onChangeMag == null)
        {
            plyaerGunInventory.curGun.onChangeMag += OnChangePlayerMag;
            plyaerGunInventory.curGun.onChangeMag?.Invoke();
        }
    }

    void OnChangePlayerMag()
    {
        magText.SetText(plyaerGunInventory.curGun.curMagazine + " / " + plyaerGunInventory.curGun.totalMagazine);
    }
}
