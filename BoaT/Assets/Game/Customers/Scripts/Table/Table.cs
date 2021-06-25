using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public SeatInfo[] seatInfo;
}
[System.Serializable]
public class SeatInfo
{
    public GameObject seatTarget;
    public bool seatIsOccupied;
    public Order.OrderType orderType;
    public List<SoulType.SoulColor> ingredients;
    public CustomerController customer;
}
