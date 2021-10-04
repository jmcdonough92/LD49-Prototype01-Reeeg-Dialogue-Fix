using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _yMin = -6;
    [SerializeField] float health = 3;
    [SerializeField] GameObject coinPrefab;
    private SoundEffects se;

    // Start is called before the first frame update
    void Start()
    {
        se = FindObjectOfType<SoundEffects>();
        StartCoroutine("CheckDespawn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageEnemy(5.0f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit bad guy!");
        DamageEnemy();
        se.PlayFlesh();
        Destroy(collider.gameObject);
    }

    private void DamageEnemy(float dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }

    private void DamageEnemy()
    {
        health--;
        if (health <= 0) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (Random.Range(0.0f, 1.0f) > 0.5f) Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator CheckDespawn()
    {
        while (true)
        {
            if (transform.position.y < _yMin)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1);

        }
    }
}
