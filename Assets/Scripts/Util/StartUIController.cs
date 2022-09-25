using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputStartButton()
    {
        playableDirector.Play();
    }

    public void StartGame()
    {

        SceneManager.LoadScene("CityTest");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
