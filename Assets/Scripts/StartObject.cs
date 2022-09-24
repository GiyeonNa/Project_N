using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour, IDamagable
{
    public WaveInfo firstWaveInfo;
    public WaveInfo curwave;
    [SerializeField] private int rotateSpeed;

    private void Awake()
    {
        curwave = firstWaveInfo;
    }

    private void Update()
    {
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        Debug.Log("Start Wave");
        GameManager.Instance.StartWave(curwave);
        //다음 웨이브 정보 가져와서 자신에게 등록
        if(curwave.nextWave != null)
        {
            //델리게이트로 변환한다면?
            curwave = curwave.nextWave;
        }
        else Debug.Log("Final Wave"); //클리어 
    }

    public void TakeHit(float damage)
    {
        return;
    }

    
}
