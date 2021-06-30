using UnityEngine;
public class CustomerSpawner : Spawner
{
    [SerializeField] private float timeBetweenSpawns;
    private float spawnerTimer;
    private bool spawnerIsFilled;
    private Table[] tablesList;
    public override void Start()
    {
        tablesList = FindObjectsOfType<Table>();
        spawnerTimer = timeBetweenSpawns;
        CalculateObjectsToInstantiate();
        base.Start();
        DeactivateObjects();
    }
    private void Update()
    {
        if (!spawnerIsFilled) SpawnerTimer();
    }
    private void CalculateObjectsToInstantiate()
    {
        Table[] tables = FindObjectsOfType<Table>();
        objectsToInstantiate = tables.Length * 4;
    }

    private void SpawnerTimer()
    {
        if (spawnerTimer > 0) spawnerTimer -= Time.deltaTime;
        else
        {
            InitializeCustomer();
            spawnerTimer = timeBetweenSpawns;
            if (activeObjects.Count == objects.Count) spawnerIsFilled = true;
        }
    }

    private void InitializeCustomer()
    {
        int currentIndex = activeObjects.Count;
        activeObjects.Add(objects[currentIndex]);
        CustomerController cc = (CustomerController)activeObjects[currentIndex];
        cc.gameObject.SetActive(true);
        int randIndex = Random.Range(0, tablesList.Length);
        SeatInfo[] seatInfos = tablesList[randIndex].seatInfo;
        for (int i = 0; i < seatInfos.Length; i++)
        {
            if (!seatInfos[i].seatIsOccupied)
            {
                cc.seatToTake = tablesList[randIndex].seatInfo[i].seatTarget;
                tablesList[randIndex].seatInfo[i].seatIsOccupied = true;
                cc.thisTable = tablesList[randIndex];
                cc.thisTable.seatInfo[i].customer = cc;
                cc.thisTableId = i;
                cc.targetedLocation = cc.seatToTake;
                break;
            }
        }
    }
}
