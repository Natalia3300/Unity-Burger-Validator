using System;
using System.Linq;
using UnityEngine;

public class BurgerValidator : MonoBehaviour
{
    [SerializeField] private string[] inputIngredients;
    [SerializeField] private Dish[] dishes;

    private void Awake()
    {
        if (Validate(inputIngredients, out string dishName))
            Debug.Log(dishName);
        else
            Debug.Log("No dish found!");
    }

    private bool Validate(string[] ingredients, out string dishName)
    {
        dishName = "";
        for (int i = 0; i < dishes.Length; i++)
        {
            if (dishes[i].Ingredients.Length == ingredients.Length)
            {
                int ingredientCount = ingredients.Length;
                for (int j = 0; j < ingredients.Length; j++)
                {
                    if (dishes[i].Ingredients.Contains(ingredients[j]))
                    {
                        ingredientCount--;
                    }
                }

                if (ingredientCount == 0)
                {
                    dishName = dishes[i].Name;
                    return true;
                }
            }
        }
        return false;
    }
}

[Serializable]
public class Dish
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string[] Ingredients { get; private set; }
}