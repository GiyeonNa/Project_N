using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour,IPickUpable
{
    [SerializeField] DropItem dropItem;

    public void PickUp()
    {
        switch (dropItem.type)
        {
            case DropItem.Type.Ammo:
                {
                    GameManager.Instance.GunInventory.curGun.totalMagazine += dropItem.amount;
                    GameManager.Instance.GunInventory.curGun.onChangeMag?.Invoke();
                    Destroy(gameObject);
                }
                break;

            case DropItem.Type.Food:
                {
                    GameManager.Instance.PlayerController.Hp += dropItem.amount;
                    Destroy(gameObject);
                }
                break;

            case DropItem.Type.Money:
                {

                    int resultMoney = dropItem.amount + UnityEngine.Random.Range(0,50);
                    
                    GameManager.Instance.PlayerController.Money += resultMoney;
                    Destroy(gameObject);
                }
                break;

            default:
                return;

        }
    }
}
