using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            Debug.Log(damageDealer.Damage);

            this.health -= damageDealer.Damage;
            damageDealer.hit();
        }

        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
