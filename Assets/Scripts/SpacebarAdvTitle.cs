using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarAdvTitle : MonoBehaviour
{
    private SceneLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loader.LoadScene();
        }
    }
}
