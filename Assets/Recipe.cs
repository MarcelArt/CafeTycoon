using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private int sugar;
    private int milk;
    private int ice;
    private int tea;
    private int coffee;
    private string drinkName;
    private float price;

    private float sweetness;
    private float coldness;

    public Recipe(string drinkName, int sugar, int milk, int ice, int tea, int coffee, float price) {
        this.drinkName = drinkName;
        this.sugar = sugar;
        this.milk = milk;
        this.ice = ice;
        this.tea = tea;
        this.coffee = coffee;
        this.price = price;
        calculateDrink();
    }

    public void calculateDrink() {
        sweetness = (sugar * 0.3f) + (milk * 0.1f) + (ice * (-0.1f)) + (tea * (-0.2f)) + (coffee * (-0.3f));
        coldness = ice * 0.3f;
    }

    public bool isToSweet() {
        return (sweetness > 1f);
    }

    public bool isToCold() {
        return (coldness > 1f);
    }

    public float getSweetness() {
        return sweetness;
    }

    public float getColdness() {
        return coldness;
    }

    public string getDrinkName() {
        return drinkName;
    }

    public float getPrice() {
        return price;
    }
    
    public int getMilk() {
        return milk;
    }

    public int getIce() {
        return ice;
    }

    public int getTea() {
        return tea;
    }

    public int getCoffee() {
        return coffee;
    }

    public int getSugar() {
        return sugar;
    }
}
