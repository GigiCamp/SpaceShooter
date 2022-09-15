using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private AudioSource explosionAudio;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        explosionAudio = GameObject.Find("AudioControllerAsteroid").GetComponent<AudioSource>();
        explosionAudio.volume = 0;
        speed = Random.Range(1, 3);
        rb.velocity = - transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.Rotate(new Vector3(2, 2, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            GameObject prefabClone = Instantiate(explosionEffect, gameObject.transform.position, gameObject.transform.rotation);
            explosionAudio.volume = 1;
            explosionAudio.Play();
            Destroy(gameObject);
            Destroy(prefabClone, 0.50f);
        }

        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AsteroidWall"))
        {
            Destroy(gameObject);
        }
    }
}
