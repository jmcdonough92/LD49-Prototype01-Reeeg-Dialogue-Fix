using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    [SerializeField] private float lerp = 0.05f;
    [SerializeField] private float wait = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine("HomeIn");
    }

    IEnumerator HomeIn()
    {
        while (transform.position.y > 5)
        {
            yield return new WaitForSeconds(0.23f);
        }
            int i = 1;
        //Quaternion rote = new Quaternion();
            while (enabled)
            {
                yield return new WaitForSeconds(wait);
            target = new Vector3(player.position.x, transform.position.y);
           // rote.SetFromToRotation(transform.position, player.position);
            transform.position = Vector3.Lerp(transform.position, target, lerp * i);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rote, lerp);
                if (i < 8) i++;
                
            }
        
    }

}
