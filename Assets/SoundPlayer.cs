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
        //������ ������ Destroy(gameObject);
        //objpool�� ����� false
        yield return null;
    }

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

}
