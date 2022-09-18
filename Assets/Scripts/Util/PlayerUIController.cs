using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public GunInventory plyaerGunInventory;

    [SerializeField] private TextMeshProUGUI magText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI hpText;


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

    public void OnChangePlayerMoney()
    {
        moneyText.SetText("Money : " + GameManager.Instance.PlayerController.Money.ToString());
    }

    public void OnChangePlayerHp()
    {
        hpText.SetText("HP : " + GameManager.Instance.PlayerController.Hp.ToString());
    }


}
