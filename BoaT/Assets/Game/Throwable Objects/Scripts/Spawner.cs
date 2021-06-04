using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    protected int objectsToInstantiate;
    [SerializeField] protected int objectsToSpawn;
    [SerializeField] private GameObject objectReference;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<GameObject> activeObjects;
    [SerializeField] private string parentObjectTag;
    private GameObject parentObject;

    public virtual void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag(parentObjectTag);
    }

    public virtual void Start()
    {
        CreateObjects();
    }

    public virtual void CreateObjects()
    {
        for (int i = 0; i < objectsToInstantiate; i++)
        {
            objects.Add(Instantiate(objectReference, parentObject.transform));
            objects[i].SetActive(false);
        }
    }
    public virtual void ActivateObjects(Vector3 positionToActivate)
    {
        if (activeObjects.Count == 0)
        {
            int countSpawnedObjects = 0;
            for (int i = 0; i < objectsToInstantiate; i++)
            {
                if (!objects[i].activeSelf)
                {
                    objects[i].transform.localPosition = positionToActivate;
                    objects[i].SetActive(true);
                    activeObjects.Add(objects[i]);
                    countSpawnedObjects++;
                }
                if (countSpawnedObjects == objectsToSpawn) break;
            }
        }
    }
    public virtual void DeactivateObjects()
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            activeObjects[i].SetActive(false);
        }
        activeObjects.Clear();
    }
}
