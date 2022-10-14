using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel()
    {
        Application.LoadLevel("Play");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        Application.LoadLevel("Start");
    }
    public void Help()
    {
        Application.LoadLevel("Help");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Application.LoadLevel("Start");
                Debug.Log("Load from end to start");
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Application.LoadLevel("Start");
                Debug.Log("Load from help to start");
            }
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("Load from start to next");
            }
        }
    }
}

