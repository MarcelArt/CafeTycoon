using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject recipeCreationUI;
    public Text sugarCounter;
    public Text milkCounter;
    public Text teaCounter;
    public Text iceCounter;
    public Text coffeeCounter;
    public InputField drinkName;
    public InputField drinkPrice;
    
    private Inventory inventory;
    private GameManager gm;
    private int sugarAmount = 0;
    private int milkAmount = 0;
    private int iceAmount = 0;
    private int teaAmount = 0;
    private int coffeeAmount= 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAddMenuPress() {
        recipeCreationUI.SetActive(true);
    }

    public void onCancelCreationPress() {
        recipeCreationUI.SetActive(false);
    }

    public void onSaveCreationPress() {
        int price = int.Parse(drinkPrice.text);
        recipeCreationUI.SetActive(false);
        gm.addNewRecipe(new Recipe(drinkName.text, sugarAmount, milkAmount, iceAmount, teaAmount, coffeeAmount, price));
    }

    //Sugar buttons
    public void addSugar() {
        if(sugarAmount<inventory.sugar) {
            sugarAmount++;
            sugarCounter.text = sugarAmount.ToString();
        }
    }
    public void removeSugar() {
        if(sugarAmount>0) {
            sugarAmount--;
            sugarCounter.text = sugarAmount.ToString();
        }
    }

    //Milk buttons
    public void addMilk() {
        if(milkAmount<inventory.milk) {
            milkAmount++;
            milkCounter.text = milkAmount.ToString();
        }
    }

    public void removeMilk() {
        if(milkAmount>0) {
            milkAmount--;
            milkCounter.text = milkAmount.ToString();
        }
    }

    //Ice buttons
    public void addIce() {
        if(iceAmount<inventory.ice) {
            iceAmount++;
            iceCounter.text = iceAmount.ToString();
        }
    }

    public void removeIce() {
        if(iceAmount>0) { 
            iceAmount--;
            iceCounter.text = iceAmount.ToString();
        }
    }

    //Tea buttons
    public void addTea() {
        if(teaAmount<inventory.tea) {
            teaAmount++;
            teaCounter.text = teaAmount.ToString();
        }
    }

    public void removeTea() {
        if(teaAmount>0) { 
            teaAmount--;
            teaCounter.text = teaAmount.ToString();
        }
    }

    //Coffee buttons
    public void addCoffee() {
        if(coffeeAmount<inventory.coffee) {
            coffeeAmount++;
            coffeeCounter.text = coffeeAmount.ToString();
        }
    }

    public void removeCoffee() {
        if(coffeeAmount>0) {
            coffeeAmount--;
            coffeeCounter.text = coffeeAmount.ToString();
        }
    }
}
