using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _yMin = -6;
    private SoundEffects se;

    // Start is called before the first frame update
    void Start()
    {
        se = FindObjectOfType<SoundEffects>();
        StartCoroutine("CheckDespawn");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit bad guy!");
        DamageEnemy();
        se.PlayFlesh();
        Destroy(collider.gameObject);
    }

    private void DamageEnemy()
    {
        Destroy(gameObject);
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
