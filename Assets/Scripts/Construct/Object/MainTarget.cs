using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private float hp;
    public float Hp 
    { 
        get 
        { 
            return hp; 
        } 
        set 
        {
            hp = value;
            targetHpText.SetText(Hp.ToString());
            if (Hp <= 0)
            {
                this.gameObject.SetActive(false);
                Hp = 0;
                GameManager.Instance.PlayableDirector.Play(GameManager.Instance.timelineClip[4]);
            }

        } 
    }

    [SerializeField] TextMeshProUGUI targetHpText;

    private void Awake()
    {
        targetHpText.SetText(Hp.ToString());
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }

    public void TakeHit(float damage)
    {
        Hp -= damage;
    }
}
