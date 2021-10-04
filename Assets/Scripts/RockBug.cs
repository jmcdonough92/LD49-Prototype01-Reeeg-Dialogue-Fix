using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBug : MonoBehaviour
{
    [SerializeField] private GameObject bugSprite;
    [SerializeField] private Homing homing;
    [SerializeField] private float y;
    public bool homeBug = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BugOut");
    }

    IEnumerator BugOut()
    {
        while (enabled)
        {
            if (transform.position.y <= y)
            {
                bugSprite.SetActive(true);
                if (homeBug) homing.enabled = true;
            }
            yield return new WaitForSeconds(0.07f);
        }
    }
}
