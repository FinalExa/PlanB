using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int objectsToInstantiate;
    [SerializeField] private int objectsToSpawn;
    [SerializeField] private GameObject objectReference;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private string parentObjectTag;
    private GameObject parentObject;

    private void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag(parentObjectTag);
    }

    private void Start()
    {
        CreateObjects();
        ActivateObjects();
    }

    private void CreateObjects()
    {
        for (int i = 0; i < objectsToInstantiate; i++)
        {
            objects.Add(Instantiate(objectReference, parentObject.transform));
            objects[i].SetActive(false);
        }
    }
    private void ActivateObjects()
    {
        int countSpawnedObjects = 0;
        for (int i = 0; i < objectsToInstantiate; i++)
        {
            if (!objects[i].activeSelf)
            {
                objects[i].SetActive(true);
                countSpawnedObjects++;
            }
            if (countSpawnedObjects == objectsToSpawn) break;
        }
    }
}
