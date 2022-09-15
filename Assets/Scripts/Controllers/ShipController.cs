using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float tilt;
    public float xMin, xMax;
    public float zMin, zMax;

    public GameObject bullet;
    public Transform spawnPosition;
    public float fireRate;
    private float nextFire;

    private AudioSource playerExplosion;
    public GameObject playerExplosionEffect;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerExplosion = GameObject.Find("AudioControllerPlayer").GetComponent<AudioSource>();
        playerExplosion.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector3(moveHorizontal, 0, moveVertical);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), rb.position.y, Mathf.Clamp(rb.position.z, zMin, zMax));
        rb.rotation = Quaternion.Euler(0, 0, - rb.velocity.x * tilt);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Asteroid"))
        {
            playerExplosion.volume = 1;
            playerExplosion.Play();
            GameObject prefabClone = Instantiate(playerExplosionEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(prefabClone, 0.50f);
        }
    }
}
