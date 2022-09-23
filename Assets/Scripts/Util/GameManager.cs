using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController{ get { return playerController; } }

    [SerializeField] private PlayerCamera playerCamera;
    public PlayerCamera PlayerCamera { get { return playerCamera; } }

    [SerializeField] private GunInventory gunInventory;
    public GunInventory GunInventory { get { return gunInventory; } }

    [SerializeField] private PlayerUIController playerUIController;
    public PlayerUIController PlayerUIController { get { return playerUIController; } }

    [SerializeField] private ObjectPoolController objectPoolController;
    public ObjectPoolController ObjectPoolController { get { return objectPoolController; } }

    public Transform[] spawnPos;
    private Vector3 plusVec;
    public GameObject StartButton;
    public bool isBattle;
    [SerializeField] WaveInfo curwaveInfo;

    //�ϴ� ��
    [SerializeField] private Renderer skyDome;
    private Vector2 nightColor = new Vector2(0.5f, 0);
    [SerializeField] private Light sunLight;
    [SerializeField] private Color sunLightColor;
    [SerializeField] private Color nightLightColor;


    public void StartWave(WaveInfo curWave)
    {
        Debug.Log(curWave.name + " Start");
        StartButton.SetActive(false);
        curwaveInfo = curWave;
        isBattle = true;
        skyDome.material.mainTextureOffset = nightColor;
        sunLight.color = nightLightColor;
        for (int i = 0; i < curWave.enemies.Length; i++)
        {
            for (int j = 0; j < curWave.enemies[i].amount; j++)
            {
                int tempPos = Random.Range(0, 4);
                plusVec = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
                ObjectPoolController.poolDic[curWave.enemies[i].type].UseObj(spawnPos[tempPos].position + plusVec, spawnPos[tempPos].rotation);
            }
        }
        #region preSpawnLogic
        //switch (curWave.enemies.Length)
        //{
        //    case 1:
        //        for(int i=0; i<curWave.enemies.Length; i++)
        //        {
        //            for(int j=0; j < curWave.enemies[i].amount; j++)
        //            {
        //                int tempPos = Random.Range(0, 4);
        //                plusVec = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
        //                ObjectPoolController.poolDic[curWave.enemies[i].type].UseObj(spawnPos[tempPos].position + plusVec, spawnPos[tempPos].rotation);
        //            }
        //        }
        //        break;
        //    case 2:
        //        break;
        //}
        ////Melee ����
        //if (curWave.enemies[0] != null)
        //{
        //    for (int i = 0; i < curWave.enemies[0].amount; i++)
        //    {
        //        int tempPos = Random.Range(0,4);
        //        plusVec = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
        //        ObjectPoolController.poolDic["Zombie_Melee"].UseObj(spawnPos[tempPos].position + plusVec, spawnPos[tempPos].rotation);
        //    }
        //}

        ////�ƿ� ������� ���� ���̺�� ��� ó���Ұ��ΰ�?
        ////Range ����
        //if (curWave.enemies[1] != null)
        //{
        //    for (int i = 0; i < curWave.enemies[1].amount; i++)
        //    {
        //        int tempPos = Random.Range(0, 4);
        //        plusVec = new Vector3(Random.Range(-3f, 3f), 0, 0);
        //        ObjectPoolController.poolDic["Zombie_Range"].UseObj(spawnPos[tempPos].position, spawnPos[tempPos].rotation);
        //    }
        //}

        //�޾ƿ� ���̺� ������ ������� ���̺����, objectpool ����
        #endregion
    }

    public void EndWave()
    {
        //���̺� �������� ���� ���̺갡 ���� == �װ� ������ ���̺꿴�ٴ� ��
        if(curwaveInfo.nextWave == null)
        {
            //���� �� �Ѿ�°� ���ƺ���
            SceneManager.LoadScene("ClearTest");
        }
        Debug.Log("End Wave");
        StartButton.SetActive(true);
        skyDome.material.mainTextureOffset = Vector2.zero;
        sunLight.color = sunLightColor;
    }
        
}
