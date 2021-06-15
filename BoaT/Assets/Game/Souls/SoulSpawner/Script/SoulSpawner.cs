using UnityEngine;
public class SoulSpawner : Spawner
{
    private BoxCollider thisTrigger;
    [SerializeField] private int soulsPerType;

    public override void Awake()
    {
        base.Awake();
        thisTrigger = this.gameObject.GetComponent<BoxCollider>();
        SoulGrabbed.soulIsGrabbed += RemoveSingleSoulFromList;
        SoulIdle.soulIsIdle += AddSingleSoulToList;
        SoulEscapePlayer.soulIsEscapingPlayer += AddSingleSoulToList;
    }

    public override void Start()
    {
        CalculateObjectsToInstantiate();
        base.Start();
        DeactivateObjects();
    }
    private void CalculateObjectsToInstantiate()
    {
        objectsToInstantiate = (int)(((thisTrigger.size.x - 1) * (thisTrigger.size.z - 1)) / 3);
    }

    private void SpawnSouls()
    {
        ActivateObjects(new Vector3(0f, 0f, 0f));
    }

    public override void ObjectActivatedSetup(int indexInObjectsList)
    {
        SetupSoul(indexInObjectsList);
    }
    private void SetupSoul(int indexInObjectsList)
    {
        SoulController sc = (SoulController)objects[indexInObjectsList];
        int soulIndex;
        if (indexInObjectsList < sc.soulTypes.Length * soulsPerType) soulIndex = indexInObjectsList / soulsPerType;
        else soulIndex = Random.Range(0, sc.soulTypes.Length);
        sc.thisSoulTypeIndex = soulIndex;
        sc.soulReferences.highlightable.thisGraphicsObject = sc.soulTypes[soulIndex].soulMeshContainer;
        sc.soulReferences.soulThrowableObject.thisGraphicsObject = sc.soulTypes[soulIndex].soulMeshContainer;
        sc.soulReferences.soulThrowableObject.SetBaseColor();
        sc.DeactivateAllSoulModels();
        sc.soulTypes[soulIndex].soulMainModelObject.SetActive(true);
    }
    public void AddSingleSoulToList(SoulController soul)
    {
        if (!activeObjects.Contains(soul)) activeObjects.Add(soul);
    }
    public void RemoveSingleSoulFromList(SoulController soul)
    {
        activeObjects.Remove(soul);
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
