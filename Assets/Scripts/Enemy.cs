using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameSession gameSession;
    [Header("Enemy")]
    [SerializeField] int health = 200;

    [Header("Laser")]
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 1f;
    [SerializeField] float laserSpeed = 20f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0f, 1f)] float shootingSoundVolume = 0.5f;
    [Header("VFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0f, 1f)] float deathSoundVolume = 0.75f;
    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(Fire());
        gameSession = FindObjectOfType<GameSession>();
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    private IEnumerator Fire()
    {

        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootingSound, transform.position, shootingSoundVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots));
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Laser")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer) { return; }
            health -= damageDealer.GetDamage();
            if (gameSession)
            {
                FindObjectOfType<GameSession>().AddToScore();
                gameSession.AddToScore();
            }
            damageDealer.Hit();
            if (health <= 0)
            {
                Kill();
            }

        }
    }

    private void Kill()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        Destroy(gameObject);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfx, durationOfExplosion);

    }
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
    //     health -= damageDealer.GetDamage();
    //     damageDealer.Hit();
    // }
}
