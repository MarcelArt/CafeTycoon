using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text sugarCounter;
    public Text milkCounter;
    public Text iceCounter;
    public Text teaCounter;
    public Text coffeeCounter;
    public Text moneyCounter;

    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        updateInvCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnEnable() {
    //     updateInvCount();
    // }

    public void updateInvCount() {
        sugarCounter.text = "Sugar (" + inventory.sugar + ")";
        milkCounter.text = "Milk (" + inventory.milk + ")";
        iceCounter.text = "Ice (" + inventory.ice + ")";
        teaCounter.text = "Tea (" + inventory.tea + ")";
        coffeeCounter.text = "Coffee (" + inventory.coffee + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }

    public void buySugar() {
        inventory.sugar+=10;
        inventory.money-=1;
        sugarCounter.text = "Sugar (" + inventory.sugar + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }

    public void buyMilk() {
        inventory.milk+=5;
        inventory.money-=1;
        milkCounter.text = "Milk (" + inventory.milk + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }

    public void buyIce() {
        inventory.ice+=20;
        inventory.money-=1;
        iceCounter.text = "Ice (" + inventory.ice + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }

    public void buyTea() {
        inventory.tea+=5;
        inventory.money-=1;
        teaCounter.text = "Tea (" + inventory.tea + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }

    public void buyCoffee() {
        inventory.coffee+=5;
        inventory.money-=2;
        coffeeCounter.text = "Coffee (" + inventory.coffee + ")";
        moneyCounter.text = "Cash: " + inventory.money;
    }
}
