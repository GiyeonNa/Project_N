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
        //다음 웨이브 정보 가져와서 자신에게 등록
        if(curwave.nextWave != null)
        {
            curwave = curwave.nextWave;
        }
        else Debug.Log("End Game"); //클리어 
    }

    public void TakeHit(float damage)
    {
        return;
    }

    
}
