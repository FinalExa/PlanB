using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public enum OrderType { Dish, Drink }
    public OrderType thisOrderType;
    public List<SoulType.SoulColor> thisOrderIngredients;

    public void SetupOrderIngredients(List<SoulType.SoulColor> ingredients)
    {
        thisOrderIngredients = ingredients;
    }
}
