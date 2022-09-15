using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private AudioSource audioFire;

    // Start is called before the first frame update
    void Start()
    {
        audioFire = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        audioFire.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletWall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
