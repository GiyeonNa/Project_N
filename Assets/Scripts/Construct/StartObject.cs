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
        //다음 웨이브 정보 가져와서 자신에게 등록
        //if (curwave.nextWave != null)
        //{
        //    //델리게이트로 변환한다면?
        //    curwave = curwave.nextWave;
        //}
        //else Debug.Log("Final Wave"); //클리어 
    }


    public void TakeHit(float damage)
    {
        return;
    }

    
}
