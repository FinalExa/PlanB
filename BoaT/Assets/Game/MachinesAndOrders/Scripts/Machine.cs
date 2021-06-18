using System.Collections.Generic;
using UnityEngine;
public class Machine : MonoBehaviour, ICanUseIngredients
{
    [HideInInspector] public List<SoulType.SoulColor> recipe;
    [SerializeField] int recipeMaxLimit;
    [SerializeField] private GameObject thisOrder;
    [SerializeField] GameObject orderOutputPosition;

    public void RecipeFill(SoulType.SoulColor ingredientType, SoulController source)
    {
        if (source.soulReferences.soulThrowableObject.isFlying && recipe.Count < recipeMaxLimit)
        {
            recipe.Add(ingredientType);
            source.gameObject.SetActive(false);
        }
    }

    public void ProduceOrder()
    {
        GameObject obj = Instantiate(thisOrder, orderOutputPosition.transform);
        obj.GetComponent<Order>().SetupOrderIngredients(recipe);
        recipe.Clear();
    }
}
