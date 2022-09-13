using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public BaseGun curGun;
    [SerializeField] private TextMeshProUGUI magText;

    private void Awake()
    {
        curGun.onChangeMag += OnChangePlayerMag;
    }
    
    void OnChangePlayerMag()
    {
        magText.SetText(curGun.curMagazine + " / " + curGun.totalMagazine);
    }
}
