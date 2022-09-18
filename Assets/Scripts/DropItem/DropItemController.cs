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
                    Debug.Log("ammo : " + dropItem.amount);
                    GameManager.Instance.GunInventory.curGun.totalMagazine += dropItem.amount;
                    GameManager.Instance.GunInventory.curGun.onChangeMag?.Invoke();
                    Destroy(gameObject);
                }
                break;

            case DropItem.Type.Food:
                {
                    GameManager.Instance.PlayerController.Hp += dropItem.amount;
                    Debug.Log("Food : " + dropItem.amount);
                    Destroy(gameObject);
                }
                break;

            case DropItem.Type.Money:
                {
                    GameManager.Instance.PlayerController.Money += dropItem.amount;
                    Debug.Log("Money : " + dropItem.amount);
                    Destroy(gameObject);
                }
                break;

            default:
                return;

        }
    }
}
