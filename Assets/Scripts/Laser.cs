using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        Clear();
    }

    void Movement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void Clear()
    {
        if (transform.position.y >= 8)
        {
            float delayToDestroy = 1.0f;
            Destroy(this.gameObject, delayToDestroy);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
