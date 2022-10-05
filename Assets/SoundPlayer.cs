using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public void PlaySouud(AudioClip audioClip)
    {
        StartCoroutine(PlayCo());
    }

    IEnumerator PlayCo()
    {
        //음악이 끝나면 Destroy(gameObject);
        //objpool로 만들면 false
        yield return null;
    }

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

}
