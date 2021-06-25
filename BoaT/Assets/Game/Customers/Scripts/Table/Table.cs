using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public SeatInfo[] seatInfo;

    public void AssignOrderToTable(int id, CustomerController customer)
    {
        seatInfo[id].orderType = customer.chosenType;
        seatInfo[id].ingredients = customer.chosenIngredients;
    }

    public void TableClear(int id)
    {
        seatInfo[id].seatIsOccupied = false;
        seatInfo[id].ingredients.Clear();
    }
}
[System.Serializable]
public class SeatInfo
{
    public GameObject seatTarget;
    public bool seatIsOccupied;
    public Order.OrderType orderType;
    public List<SoulType.SoulColor> ingredients;
}
