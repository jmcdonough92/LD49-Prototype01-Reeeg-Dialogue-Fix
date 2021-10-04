using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpacebarAdv : MonoBehaviour
{

    private DialogueUI dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueUI.MarkLineComplete();
        }
    }
}
