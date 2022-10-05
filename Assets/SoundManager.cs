using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public GameObject soundPrafab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play(AudioClip audioClip)
    {
        Instantiate(soundPrafab, transform).GetComponent<SoundPlayer>().PlaySouud(audioClip);
    }
    public void Play(string clipName)
    {
        Instantiate(soundPrafab, transform).GetComponent<SoundPlayer>().PlaySouud(Resources.Load<AudioClip>("/Sound/"+clipName));
    }

}
