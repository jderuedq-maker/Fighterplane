using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;
    private float horizontalScreenLimit = 9.5f;

    public GameObject bulletPrefab;
    public GameObject shieldObject;
    public AudioClip powerupSound;
    public AudioClip powerdownSound;

    private bool shieldActive = false;
    private AudioSource audioSource;

    void Start()
    {
        playerSpeed = 8f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        if (transform.position.x > horizontalScreenLimit)
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        else if (transform.position.x < -horizontalScreenLimit)
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -3f, 0f),
            0
        );
    }

    void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "shield")
        {
            Destroy(whatDidIHit.gameObject);
            shieldActive = true;

            if (audioSource != null && powerupSound != null)
                audioSource.PlayOneShot(powerupSound);

            if (shieldObject != null)
            {
                shieldObject.SetActive(true);
                StartCoroutine(ShieldTimer());
            }
        }
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(5f);
        shieldActive = false;

        if (audioSource != null && powerdownSound != null)
            audioSource.PlayOneShot(powerdownSound);

        if (shieldObject != null)
            shieldObject.SetActive(false);
    }
}