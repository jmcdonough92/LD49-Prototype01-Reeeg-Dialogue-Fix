using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnDestroy : MonoBehaviour
{
    public SceneLoader sl;
    public bool lastScene = false;

    private void OnDestroy()
    {
        if (lastScene)
        {
            sl.LoadScene();
        }
        else
        {
            sl.LoadNextScene();
        }
    }

}
