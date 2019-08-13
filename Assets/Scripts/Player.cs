using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speed = 10f;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 0.5f;
    [SerializeField] int health = 300;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip shootingSound;

    [Header("Projectile")]
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] float baseLazerSpeed = 10f;
    [SerializeField] float autoshootIUnterval = 0.5f;


    float maxX;
    float minX;
    float maxY;
    float minY;

    Coroutine fieringCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        setUpWorldBoundaries();
    }



    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.GetComponent<DamageDealer>();
        
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
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    private void fire ()
    {

        if (Input.GetButtonDown("Fire1") && fieringCoroutine == null)
        {
            fieringCoroutine = StartCoroutine(autoFire());
        }

        if (Input.GetButtonUp("Fire1") && fieringCoroutine != null)
        {
            StopCoroutine(fieringCoroutine);
            fieringCoroutine = null;
        }
    }

    private IEnumerator autoFire()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(shootingSound, transform.position);

            var shotPosition = new Vector3(transform.position.x, transform.position.y + yPadding, transform.position.z);
            var shot = Instantiate(lazerPrefab, shotPosition, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, baseLazerSpeed);

            yield return new WaitForSeconds(autoshootIUnterval);
        }
    }


    private void setUpWorldBoundaries ()
    {
        Camera gameCamera = Camera.main;

        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;

        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
    }

    private void move()
    {
        transform.position = new Vector2(getNewXPos(), getNewYPos());
    }

    private float getNewXPos()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX * Time.deltaTime * speed;

        return Mathf.Clamp(newXPos, minX, maxX);
    }

    private float getNewYPos()
    {
        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY * Time.deltaTime * speed;

        return Mathf.Clamp(newYPos, minY, maxY);
    }

}
