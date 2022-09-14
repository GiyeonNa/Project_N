using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public GunInventory gunInventory;
    [SerializeField] public BaseGun UIcurGun;
    [SerializeField] private TextMeshProUGUI magText;


    private void Start()
    {
        UIcurGun = gunInventory.curGun;
        UIcurGun.onChangeMag += OnChangePlayerMag;
    }

    private void Update()
    {
        UIcurGun = gunInventory.curGun;
    }

    void OnChangePlayerMag()
    {
        magText.SetText(UIcurGun.curMagazine + " / " + UIcurGun.totalMagazine);
    }
}
