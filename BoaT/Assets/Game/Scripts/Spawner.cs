using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    protected int objectsToInstantiate;
    protected int objectsToSpawn;
    [SerializeField] protected List<GameObject> objects;
    [SerializeField] protected List<GameObject> activeObjects;
    [SerializeField] private GameObject objectReference;
    [SerializeField] private string parentObjectTag;
    private GameObject parentObject;
    public SpawnerData spawnerData;

    public virtual void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag(parentObjectTag);
    }

    public virtual void Start()
    {
        CreateObjects();
        SetObjectsToSpawnNumber();
    }

    public virtual void CreateObjects()
    {
        for (int i = 0; i < objectsToInstantiate; i++)
        {
            objects.Add(Instantiate(objectReference, parentObject.transform));
            objects[i].SetActive(false);
        }
    }
    private void SetObjectsToSpawnNumber()
    {
        objectsToSpawn = spawnerData.objectsToSpawn;
        if (objectsToSpawn < 0 || objectsToSpawn > objectsToInstantiate) objectsToSpawn = (int)Mathf.Lerp(0, objectsToInstantiate, 1);
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
                    ObjectActivatedSetup(i);
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

    public virtual void ObjectActivatedSetup(int indexInObjectsList)
    {
        return;
    }
}
