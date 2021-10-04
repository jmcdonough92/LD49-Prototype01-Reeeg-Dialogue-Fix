using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndex = 1;

    private bool playerDeath = false;

    public void PlayerDeathLoadScene()
    {
        playerDeath = true;
        LoadNextScene();
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadNextScene()
    {
        if (playerDeath)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        }
        else
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
