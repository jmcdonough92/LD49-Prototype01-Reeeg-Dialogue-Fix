using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnDestroy : MonoBehaviour
{
    public SceneLoader sl;

    private void OnDestroy()
    {
        sl.LoadScene();
    }

}
