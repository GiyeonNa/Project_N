using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class MainTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private float hp;
    [SerializeField] private Collider[] colliders;

    public UnityAction OnChangeTargetHp;
    public float Hp 
    { 
        get 
        { 
            return hp; 
        } 
        set 
        {
            
            if (hp <= 10)
            {
                foreach (Collider col in colliders)
                {
                    col.enabled = false;
                }

                GameManager.Instance.PlayableDirector.Play(GameManager.Instance.timelineClip[4]);
            }
            hp = value;

            //targetHpText.SetText(Hp.ToString());
            OnChangeTargetHp?.Invoke();
            

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
