using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject VFXExplotion;
    public float scaleFactor = 1;
    public Color myColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("Base_Color", myColor);
        StartCoroutine(ScaleCube());
    }

    IEnumerator ScaleCube()
    {
        float currentScale = 0;

        while(currentScale < scaleFactor)
        {
            yield return null;
            currentScale = Mathf.Lerp(currentScale, scaleFactor, Time.deltaTime);
            transform.localScale = Vector3.one * currentScale;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Instantiate(VFXExplotion, transform.position, Quaternion.identity);
            
            CubesPool.targetCount--;
            GameManager.sessionScore += 1 / scaleFactor;

            if (CubesPool.targetCount <= 0)
                CubesPool.IsEmpty();

            gameObject.SetActive(false);
        }    
    }
}
