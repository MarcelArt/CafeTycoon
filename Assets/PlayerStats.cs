using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static List<Recipe> recipes;
    private static int sugar, milk, ice, tea, coffee;
    private static float money;

    public static List<Recipe> getRecipes() {
        return recipes;
    }

    public static int getSugar() {
        return sugar;
    }

    public static int getMilk() {
        return milk;
    }

    public static int getIce() {
        return ice;
    }

    public static int getTea() {
        return tea;
    }

    public static int getCoffee() {
        return coffee;
    }

    public static float getMoney() {
        return money;
    }
}
