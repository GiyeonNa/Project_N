using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public GunInventory plyaerGunInventory;
    [SerializeField] public MainTarget mainTarget;

    [SerializeField] private TextMeshProUGUI magText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI targetHpText;


    //hit effect
    [SerializeField] private Image redLineImage;
   

    private void Start()
    {
        //UIcurGun = plyaerGunInventory.curGun;
        //UIcurGun.onChangeMag += OnChangePlayerMag;
        plyaerGunInventory.curGun.onChangeMag += OnChangePlayerMag;
        mainTarget.OnChangeTargetHp += OnChangeTargetHp;

        plyaerGunInventory.curGun.onChangeMag?.Invoke();
        OnChangePlayerMoney();
        OnChangePlayerHp();
        OnChangeTargetHp();

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
        moneyText.SetText(GameManager.Instance.PlayerController.Money.ToString() + "$");
    }

    public void OnChangePlayerHp()
    {
        hpText.SetText(GameManager.Instance.PlayerController.Hp.ToString());
    }

    public void OnChangeTargetHp()
    {
        targetHpText.SetText(mainTarget.Hp.ToString());
    }


    public IEnumerator ChangeAll()
    {
        hpText.SetText(GameManager.Instance.PlayerController.Hp.ToString());
        redLineImage.color = new Color(1, 0, 0, 1);
        float fadeColor = 1;
        while (fadeColor >= 0f)
        {
            fadeColor -= 0.1f;
            yield return new WaitForSeconds(0.01f);
            redLineImage.color = new Color(1, 0, 0, fadeColor);
        }
    }


}
