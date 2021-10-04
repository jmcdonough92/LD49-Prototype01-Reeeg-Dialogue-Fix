using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobstrosity : MonoBehaviour
{
    [SerializeField] private float health = 300;
    [SerializeField] private MoveDown md;
    [SerializeField] private float yMin = 3.5f;
    [SerializeField] private float yMax = 4.0f;
    [SerializeField] private float xMin = -1.9f;
    [SerializeField] private float xMax = 1.9f;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Transform shooter;
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private float shotDamage = 1;
    [SerializeField] private Animator animator;
    private SoundEffects se;

    // Start is called before the first frame update
    void Start()
    {
        se = FindObjectOfType<SoundEffects>();
        StartCoroutine("CheckDespawn");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit the Gobstrosity!");
        DamageEnemy();
        se.PlayFlesh();
        Destroy(collider.gameObject);
    }

    private void DamageEnemy()
    {
        health -= shotDamage;
        if(health<1) Destroy(gameObject);
    }

    IEnumerator CheckDespawn()
    {
        bool movingToPlayer = true;
        while (movingToPlayer)
        {
            if (transform.position.y < yMin)
            {
                md.enabled = false;
                StartCoroutine("MoveSideways");
                StartCoroutine("BobUpDown");
                StartCoroutine("GobAttack");
                movingToPlayer = false;
            }
            yield return new WaitForSeconds(0.3f);

        }
    }

    private void Shoot()
    {
        Instantiate(_shotPrefab, shooter.position, Quaternion.AngleAxis(180, transform.forward));
        Instantiate(_shotPrefab, shooter.position, Quaternion.AngleAxis(160, transform.forward));
        Instantiate(_shotPrefab, shooter.position, Quaternion.AngleAxis(200, transform.forward));
    }

    void GobBobNWeave()
    {
        //start movement coroutines
    }

    IEnumerator GobAttack()
    {
        float timeToAttack = Random.Range(1, 2);

        while (health>0)
        {
            yield return new WaitForSeconds(timeToAttack);
            animator.SetBool("fire",true);
            yield return new WaitForSeconds(1.1f);
            animator.SetBool("fire", false);
            Shoot();
            timeToAttack = Random.Range(0.4f, 0.5f);
        }

        //start coroutine for charge and shoot
    }

    //These need to detect the moment an extreme is reached and change state w a bool
    IEnumerator BobUpDown()
    {
        bool bobbingUp = true;
        while (health>0)
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
        while (health>0)
        {

            while (movingRight)
            {

                transform.position += Vector3.right * speed* Time.deltaTime;
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
