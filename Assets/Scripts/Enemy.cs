using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeShots = 0.3f;
    [SerializeField] float maxTimeShots = 2f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectSpeed = 10f;
    [SerializeField] GameObject particlesExplosion;
    [SerializeField] int pointsPerEnemy = 50;
    

    [SerializeField] AudioClip laserAudio;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.25f;

    [SerializeField] AudioClip audioDie;
    [SerializeField] [Range(0, 1)] float audioDieVolume = 0.75f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeShots, maxTimeShots);

    }

    // Update is called once per frame
    void Update()
    {
        ShotsCountDown();
    }

    private void ShotsCountDown()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeShots, maxTimeShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectSpeed);
        AudioSource.PlayClipAtPoint(laserAudio, Camera.main.transform.position, laserSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        Hit(damageDealer);
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
        FindObjectOfType<GameSession>().addScore(pointsPerEnemy);
        Destroy(gameObject);
        GameObject explosion = Instantiate(particlesExplosion, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(audioDie, Camera.main.transform.position, audioDieVolume);
    }
}
