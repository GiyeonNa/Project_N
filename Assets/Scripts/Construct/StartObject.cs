using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour, IDamagable
{
    
    [SerializeField] private int rotateSpeed;

   
    private void Update()
    {
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        Debug.Log("Start Wave");
        //GameManager.Instance.StartWave(curwave);
        //turn night
        GameManager.Instance.PlayableDirector.Play(GameManager.Instance.timelineClip[1]);
        //GameManager.Instance.StartWave();
        //���� ���̺� ���� �����ͼ� �ڽſ��� ���
        //if (curwave.nextWave != null)
        //{
        //    //��������Ʈ�� ��ȯ�Ѵٸ�?
        //    curwave = curwave.nextWave;
        //}
        //else Debug.Log("Final Wave"); //Ŭ���� 
    }


    public void TakeHit(float damage)
    {
        return;
    }

    
}
