using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour, IDamagable
{
    public WaveInfo firstWaveInfo;
    public WaveInfo curwave;

    private void Awake()
    {
        curwave = firstWaveInfo;
    }
    public void TakeHit(float damage, RaycastHit hit)
    {
        Debug.Log("Start Wave");
        GameManager.Instance.StartWave(curwave);
        //���� ���̺� ���� �����ͼ� �ڽſ��� ���
        if(curwave.nextWave != null)
        {
            curwave = curwave.nextWave;
        }
        else Debug.Log("End Game"); //Ŭ���� 
    }

    public void TakeHit(float damage)
    {
        return;
    }

    
}
