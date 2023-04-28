using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    AudioSource sfx;
    void Start()
    {
        Destroy(gameObject, 5f); 
    }
}
