using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobNWeave : MonoBehaviour
{
    [SerializeField] private float yMin = 3.5f;
    [SerializeField] private float yMax = 4.0f;
    [SerializeField] private float xMin = -1.9f;
    [SerializeField] private float xMax = 1.9f;
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private MoveDown md;
    [SerializeField] private Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CheckY");
    }
    IEnumerator CheckY()
    {
        bool movingToPlayer = true;
        while (movingToPlayer)
        {
            if (transform.position.y < yMin)
            {
                md.enabled = false;
                StartCoroutine("MoveSideways");
                StartCoroutine("BobUpDown");
                StartCoroutine("Attack");
                movingToPlayer = false;
            }
            yield return new WaitForSeconds(0.3f);

        }
    }

    IEnumerator Attack()
    {
        float timeToAttack = Random.Range(3, 5);

        while (enabled)
        {
            yield return new WaitForSeconds(timeToAttack);
            shooter.ShootDown(1);
            timeToAttack = Random.Range(1, 2);
        }

        //start coroutine for charge and shoot
    }

    IEnumerator BobUpDown()
    {
        bool bobbingUp = true;
        while (enabled)
        {

            while (bobbingUp)
            {

                transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.y > yMax) bobbingUp = false;
                yield return null;
            }
            while (!bobbingUp)
            {

                transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y < yMin) bobbingUp = true;
                yield return null;
            }
        }
    }

    IEnumerator MoveSideways()
    {
        bool movingRight = true;
        while (enabled)
        {

            while (movingRight)
            {

                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x > xMax) movingRight = false;
                yield return null;
            }
            while (!movingRight)
            {

                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x < xMin) movingRight = true;
                yield return null;
            }
        }
    }
}
