using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    private int amountToPool;

    public delegate void PoolDelegate();
    public static PoolDelegate IsEmpty;

    public Color[] availableColors;
    public static int targetCount;

    void Awake()
    {
        amountToPool = Random.Range(20, 40);
        targetCount = amountToPool;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
            GenerateCubes();    

        InvokeRepeating("RevealCubes", 3f, 0.2f);
    }

    void GenerateCubes()
    {
        GameObject temporal;

        Vector3 target_Position = new Vector3(Random.Range(-4f, 5f),
                                              Random.Range(3f, 9f),
                                              Random.Range(-4f, 5f));

        Vector3 target_Rotation = new Vector3(0, Random.Range(0, 360), 0);

        Quaternion target_Quaternion = Quaternion.Euler(target_Rotation);
      
        temporal = Instantiate(objectToPool, target_Position, target_Quaternion);

        float scaleDactor = Random.Range(2, 10) * 0.1f;

        Target target = temporal.GetComponent<Target>();
        target.scaleFactor = scaleDactor;
        target.myColor = availableColors[Random.Range(0, availableColors.Length)];

        pooledObjects.Add(temporal);
    }
    int index = 0;

    void RevealCubes()
    {
        if (index >= pooledObjects.Count) return;

        pooledObjects[index].SetActive(true);
        index++;
    }
}
