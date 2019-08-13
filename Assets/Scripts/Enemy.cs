using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ship")]
    [SerializeField] int health = 100;
    
    [Header("shooting")]
    [SerializeField] float minTimeBetweenShots = 0.1f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] float baseLazerSpeed = 10f;
    [SerializeField] GameObject lazerPrefab;
    
    [Header("animation")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] private float explosionLifetime = 0.5f;

    [Header("audio")]
    [SerializeField] private AudioClip[] shootingSounds;
    [SerializeField] private AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(autoFire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator autoFire()
    {
        while (true)
        {
            launchProjectile();

            if (shootingSounds.Length > 0) {
                AudioSource.PlayClipAtPoint(shootingSounds[Random.Range(0, shootingSounds.Length)], transform.position);
            } else {
                Debug.LogError("No sound effects for shooting");
            }
            
            yield return new WaitForSeconds(Random.Range(minTimeBetweenShots, maxTimeBetweenShots));
        }
    }

    private void launchProjectile()
    {
        var shotPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var shot = Instantiate(lazerPrefab, shotPosition, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -baseLazerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
        {
            return;
        }

        handleHit(damageDealer);
    }

    private void handleHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        
        damageDealer.hit();

        if (health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        explode();
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void explode()
    {
        var explosionPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
        Destroy(explosion, explosionLifetime);
    }
}
