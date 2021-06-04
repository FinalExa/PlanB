using UnityEngine;
public class SoulSpawner : Spawner
{
    private BoxCollider thisTrigger;

    public override void Awake()
    {
        base.Awake();
        thisTrigger = this.gameObject.GetComponent<BoxCollider>();
    }

    public override void Start()
    {
        CalculateObjectsToInstantiate();
        base.Start();
    }
    void CalculateObjectsToInstantiate()
    {
        objectsToInstantiate = (int)(((thisTrigger.size.x - 1) * (thisTrigger.size.z - 1)) / 3);
        if (objectsToSpawn < 0 || objectsToSpawn > objectsToInstantiate) objectsToSpawn = (int)Mathf.Lerp(0, objectsToInstantiate, 1);
    }

    private void AssignCoordinatesToObjects()
    {
        ActivateObjects(new Vector3(0f, 0f, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) AssignCoordinatesToObjects();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) DeactivateObjects();
    }
}
