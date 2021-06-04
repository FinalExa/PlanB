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
    }

    private void SpawnSouls()
    {
        ActivateObjects(new Vector3(0f, 0f, 0f));
    }

    public override void ObjectActivatedSetup(int indexInObjectsList)
    {
        SetupSoulColors(indexInObjectsList);
    }
    private void SetupSoulColors(int indexInObjectsList)
    {
        SoulController sc = objects[indexInObjectsList].gameObject.GetComponent<SoulController>();
        int soulIndex = Random.Range(0, sc.soulTypes.Length);
        sc.thisSoulTypeIndex = soulIndex;
        sc.soulTypes[soulIndex].soulMeshContainer.transform.parent.gameObject.SetActive(true);
        sc.soulReferences.highlightable.thisGraphicsObject = sc.soulTypes[soulIndex].soulMeshContainer;
        sc.soulReferences.soulThrowableObject.thisGraphicsObject = sc.soulTypes[soulIndex].soulMeshContainer;
        sc.soulReferences.soulThrowableObject.SetBaseColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) SpawnSouls();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) DeactivateObjects();
    }
}
