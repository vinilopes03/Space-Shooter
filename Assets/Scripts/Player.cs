using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour

{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] float health = 200f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectSpeed = 10f;
    [SerializeField] float delay = 0.1f;
    [SerializeField] AudioClip laserAudio;
    [SerializeField][Range(0,1)] float laserSoundVolume = 0.25f;

    [SerializeField] AudioClip audioDie;
    [SerializeField] [Range(0, 1)] float dieAudioVolume = 0.75f;
    [SerializeField] GameObject particlesExplosion;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    bool hasShot;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        hasShot = false;
        
        myAudioSource = GetComponent<AudioSource>();
        
    }

    private void setMoveBoundaries()
    {
       /* Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x +padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x -padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y +padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y -padding;*/

    }

    // Update is called once per frame
    void Update()
    {
     
        Move();
        Fire();
        
        
    }
    
    public float getHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            health = 0;
            Die();
        }
        else
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer) { return; }
            Hit(damageDealer);
        }

    }
    private void Hit(DamageDealer damageDealer)
    {
        health -= damageDealer.getDamaged();
        damageDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(gameObject);
        FindObjectOfType<Level>().LoadGameOver();
        GameObject explosion = Instantiate(particlesExplosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(audioDie, Camera.main.transform.position, dieAudioVolume);
    }



    private void Fire()
    {
        if (Input.GetButton("Fire1") && hasShot==false)
        {

           GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
           laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectSpeed);
            AudioSource.PlayClipAtPoint(laserAudio, Camera.main.transform.position, laserSoundVolume);
            StartCoroutine(ShotAndWait());
            
        }
    }

    IEnumerator ShotAndWait()
    {
        hasShot = true;
        yield return new WaitForSeconds(delay);
        hasShot = false;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        var newXPos = Mathf.Clamp(transform.position.x+deltaX, -5 , 5);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, -9, 9);

        transform.position = new Vector2(newXPos, newYPos);

    }
}
