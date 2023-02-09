using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject ESC;
    public void GoSceneName()
    {
        SceneManager.LoadScene(gameObject.name);
    }
    public void RESUME()
    {
        ESC.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
