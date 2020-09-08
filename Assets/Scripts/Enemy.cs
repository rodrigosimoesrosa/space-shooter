using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        Respawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HittedByPlayer(other.transform.GetComponent<Player>());
        }

        if (other.tag == "Laser")
        {
            HittedByLaser(other.transform.GetComponent<Laser>());
        }
    }

    void HittedByPlayer(Player player)
    {
        if (player != null)
        {
            player.Damage();
        }
        
        DestroyEnemy();
    }

    void HittedByLaser(Laser laser)
    {
        if (laser != null)
        {
            laser.Destroy();
        }

        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void Respawn()
    {
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }
}
