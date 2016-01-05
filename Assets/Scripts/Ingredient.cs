using UnityEngine;
using System.Collections;

public class Ingredient {

    IngredientServingType servingType;
    Fraction servingSize;
    string name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string DisplayIngredient()
    {
        Debug.Log()
        return 
    }
}

public enum IngredientServingType
{
    Ounces,
    Cup,
    Teaspoon,
    Tablespoon,
    Quantity
}
