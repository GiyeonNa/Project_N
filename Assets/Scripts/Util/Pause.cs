using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject pauseGroup;
    [SerializeField] public bool isShow;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isShow)
                ShowPause();
            else
                HidePause();
        }
    }

    public void ShowPause()
    {
        Cursor.lockState = CursorLockMode.None;
        isShow = true;
        Time.timeScale = 0;
        pauseGroup.SetActive(true);
    }

    public void HidePause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isShow = false;
        Time.timeScale = 1;
        pauseGroup.SetActive(false);
    }

    public void ResumButton()
    {
        isShow = false;
        Time.timeScale = 1;
        pauseGroup.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
        isShow = false;
        Time.timeScale = 1;
        Application.Quit();
    }
}
