using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Timeline;
using UnityEngine.Playables;

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

    [SerializeField] private CraftManual craftManual;
    public CraftManual CraftManual { get { return craftManual; } }

    [SerializeField] public Pause pause;

    public Transform[] spawnPos;
    private Vector3 plusVec;
    public GameObject StartButton;
    public bool isBattle;
    [SerializeField] private WaveInfo curwaveInfo;

    //하늘 빛
    [SerializeField] private Renderer skyDome;
    private Vector2 nightColor = new Vector2(0.5f, 0);
    [SerializeField] private Light sunLight;
    [SerializeField] private Color sunLightColor;
    [SerializeField] private Color nightLightColor;

    //fade
    public Image fadeImg;

    //TimeLine
    [SerializeField] private PlayableDirector playableDirector;
    public PlayableDirector PlayableDirector { get { return playableDirector; } }
    public TimelineAsset[] timelineClip;


    //public void StartWave(WaveInfo curWave)
    //{
    //    Debug.Log(curWave.name + " Start");
    //    StartButton.SetActive(false);
    //    curwaveInfo = curWave;
    //    isBattle = true;
    //    for (int i = 0; i < curWave.enemies.Length; i++)
    //    {
    //        for (int j = 0; j < curWave.enemies[i].amount; j++)
    //        {
    //            int tempPos = Random.Range(0, 4);
    //            plusVec = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
    //            ObjectPoolController.poolDic[curWave.enemies[i].type].UseObj(spawnPos[tempPos].position + plusVec, spawnPos[tempPos].rotation);
    //        }
    //    }
    //}

    public void StartWave()
    {
        StartButton.SetActive(false);
        isBattle = true;
        for (int i = 0; i < curwaveInfo.enemies.Length; i++)
        {
            for (int j = 0; j < curwaveInfo.enemies[i].amount; j++)
            {
                int tempPos = Random.Range(0, 4);
                plusVec = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
                ObjectPoolController.poolDic[curwaveInfo.enemies[i].type].UseObj(spawnPos[tempPos].position + plusVec, spawnPos[tempPos].rotation);
            }
        }
    }

    public void ChangeLightToNight()
    {
        skyDome.material.mainTextureOffset = nightColor;
        sunLight.color = nightLightColor;
    }

    public void ChangeLightToDay()
    {
        skyDome.material.mainTextureOffset = Vector2.zero;
        sunLight.color = sunLightColor;
    }

    public void FadeImgDeAct()
    {
        fadeImg.gameObject.SetActive(false);
    }

    public void ClaerGame()
    {
        SceneManager.LoadScene("ClearTest");
    }

    public void BadEnd()
    {
        SceneManager.LoadScene("DeadTest");
    }


    public void EndWave()
    {
        //웨이브 마무리후 다음 웨이브가 없음 == 그게 마지막 웨이브였다는 뜻
        if(curwaveInfo.nextWave == null)
        {
            //연출 후 넘어가는게 좋아보임
            PlayableDirector.Play(timelineClip[3]);
        }
        if (curwaveInfo.nextWave != null)
        {
            curwaveInfo = curwaveInfo.nextWave;
        }
        Debug.Log("End Wave");
        StartButton.SetActive(true);
    }


}
