﻿using System.Collections.Generic;
using UnityEngine;
public class CustomerSpawner : Spawner
{
    [SerializeField] private float timeBetweenSpawns;
    private float spawnerTimer;
    private bool spawnerIsFilled;
    [SerializeField] private List<SeatInfo> freeSeats;
    private Table[] tablesList;
    public override void Start()
    {
        spawnerTimer = timeBetweenSpawns;
        CalculateObjectsToInstantiate();
        base.Start();
        SetupFreeSeats();
    }
    private void Update()
    {
        if (!spawnerIsFilled) SpawnerTimer();
    }
    private void CalculateObjectsToInstantiate()
    {
        tablesList = FindObjectsOfType<Table>();
        objectsToInstantiate = tablesList.Length * 4;
    }

    private void SetupFreeSeats()
    {
        foreach (Table table in tablesList)
        {
            for (int i = 0; i < table.seatInfo.Length; i++)
            {
                freeSeats.Add(table.seatInfo[i]);
            }
        }
    }

    private void SpawnerTimer()
    {
        if (spawnerTimer > 0) spawnerTimer -= Time.deltaTime;
        else
        {
            SearchForFreeSeat();
            spawnerTimer = timeBetweenSpawns;
            if (activeObjects.Count == objects.Count) spawnerIsFilled = true;
        }
    }

    private void SearchForFreeSeat()
    {
        int currentIndex = activeObjects.Count;
        activeObjects.Add(objects[currentIndex]);
        CustomerController cc = (CustomerController)activeObjects[currentIndex];
        int randomIndex = Random.Range(0, freeSeats.Count);
        StartupCustomer(cc, randomIndex);
    }

    private void StartupCustomer(CustomerController cc, int seatIndex)
    {
        cc.seatToTake = freeSeats[seatIndex].seatTarget;
        cc.thisTable = freeSeats[seatIndex].thisTable;
        freeSeats[seatIndex].customer = cc;
        cc.thisTableId = freeSeats[seatIndex].thisId;
        cc.targetedLocation = cc.seatToTake;
        cc.gameObject.SetActive(true);
        freeSeats.RemoveAt(seatIndex);
    }
}
