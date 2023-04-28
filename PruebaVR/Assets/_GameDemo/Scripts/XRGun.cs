using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRGun : MonoBehaviour
{
    public InputActionReference fireReference = null;
    public InputActionReference pauseReference = null;
    public GameObject projectile;

    [SerializeField] Transform spawnPoint;
    [SerializeField] ParticleSystem muzzle;

    private bool gameIsPaused = false;

    void Awake()
    {
        fireReference.action.started += Fire;
        pauseReference.action.started += Pause;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(projectile, spawnPoint.position, transform.rotation);
        muzzle.Play();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (gameIsPaused)
        {
            Time.timeScale = 1.0f;
            gameIsPaused = false;
        }
            
        else
        {
            Time.timeScale = 0.0f;
            gameIsPaused = true;
        }
            
    }
}
