﻿using System.Collections.Generic;
using UnityEngine;
public class Machine : MonoBehaviour, ICanUseIngredients, ICanBeInteracted
{
    [HideInInspector] public List<SoulType.SoulColor> recipe;
    [HideInInspector] public GameObject Self { get; set; }
    [SerializeField] int recipeMaxLimit;
    [SerializeField] private GameObject thisOrder;
    [SerializeField] GameObject orderOutputPosition;
    private void Start()
    {
        Self = this.gameObject;
    }

    public void RecipeFill(SoulType.SoulColor ingredientType, SoulController source)
    {
        if (source.soulReferences.soulThrowableObject.isFlying && recipe.Count < recipeMaxLimit)
        {
            recipe.Add(ingredientType);
            source.gameObject.SetActive(false);
            if (recipe.Count == recipeMaxLimit) ProduceOrder();
        }
    }

    public void ProduceOrder()
    {
        GameObject obj = Instantiate(thisOrder, orderOutputPosition.transform);
        obj.GetComponent<Order>().SetupOrderIngredients(recipe);
        recipe.Clear();
    }

    public void Interaction()
    {
        if (recipe.Count > 0) ProduceOrder();
    }
}
