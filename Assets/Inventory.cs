using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int sugar;
    public int milk;
    public int ice;
    public int tea;
    public int coffee;
    public float money;
    public Text moneyCounter;

    // private ShopManager shopManager;

    private void Start() {
    }

    public void useRecipe(Recipe R) {
        sugar -= R.getSugar();
        milk -= R.getMilk();
        ice -= R.getIce();
        tea -= R.getTea();
        coffee -= R.getCoffee();
        money += R.getPrice();
        // moneyCounter.text = "Cash: " + money;
    }

    public override string ToString()
    {
        string inventory = 
            "{\n\tsugar: " + sugar +
            "\n\tmilk: " + milk +
            "\n\tice: " + ice +
            "\n\ttea: " + tea +
            "\n\tcoffee: " + coffee +
            "\n}";
        return inventory;
    }

    public bool isAvailable(Recipe R) {
        return (
            sugar >= R.getSugar() &&
            milk >= R.getMilk() &&
            ice >= R.getIce() &&
            tea >= R.getTea() &&
            coffee >= R.getCoffee()
        );
    }
}
