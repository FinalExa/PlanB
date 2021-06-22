using UnityEngine;

public class IngredientLights : MonoBehaviour, IHaveIngredientLights
{
    [SerializeField] private Renderer[] lights;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color testColor;

    private void Start()
    {
        ResetAllLights();
    }

    public void ActivateLight(Machine machine)
    {
        lights[machine.recipe.Count - 1].material.color = testColor;
    }

    public void ResetAllLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].material.color = baseColor;
        }
    }
}
