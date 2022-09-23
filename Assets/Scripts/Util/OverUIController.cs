using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUIController : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("StartTest");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
