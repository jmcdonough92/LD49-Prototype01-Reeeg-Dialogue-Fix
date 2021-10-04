using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScroll : MonoBehaviour
{
    [SerializeField] Vector3 interval = new Vector3(0, -0.05f);
    [SerializeField] int iterations = 30;
    [SerializeField] float wait = 0.23f;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        StartCoroutine("Scroll");
    }

    IEnumerator Scroll()
    {
        while (true)
        {
            for (int i = 0; i < iterations; i++)
            {
                transform.position += interval;
                yield return new WaitForSeconds(wait);
            }
            transform.position = initialPos;
        }

    }

}
