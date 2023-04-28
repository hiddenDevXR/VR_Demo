using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3f;
    int hits;

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Wall"))
            hits++;

        if (hits >= 3)
            Destroy(gameObject);
    }
}
