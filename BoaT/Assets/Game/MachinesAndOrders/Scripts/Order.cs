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
        print(thisOrderType);
        foreach (SoulType.SoulColor ingredient in thisOrderIngredients)
        {
            print(ingredient);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            Table otherTable = other.GetComponent<Table>();
            otherTable.RecipeCheck(thisOrderType, thisOrderIngredients, this.gameObject);
        }
    }
}
