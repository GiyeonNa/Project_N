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
        //���� ���̺� ���� �����ͼ� �ڽſ��� ���
        if(curwave.nextWave != null)
        {
            //��������Ʈ�� ��ȯ�Ѵٸ�?
            curwave = curwave.nextWave;
        }
        else Debug.Log("Final Wave"); //Ŭ���� 
    }

    public void TakeHit(float damage)
    {
        return;
    }

    
}
