using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField] private float _ttl;
    [SerializeField] private float _speed;
    private float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _ttl);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up) * direction * _speed * Time.deltaTime;
    }


}
