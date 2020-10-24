using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrepMenuManager : MonoBehaviour
{
    public static PrepMenuManager instance;
    public GameObject shopPanel;
    public GameObject menuPanel;
    public GameObject makerPanel;
    public GameObject reportPanel;
    public GameObject menuText;
    public InputField nameInput;
    public InputField priceInput;
    public InputField sugarInput;
    public InputField milkInput;
    public InputField iceInput;
    public InputField teaInput;
    public InputField coffeeInput;
    public RectTransform menuScrollView;

    private List<Recipe> recipes;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        recipes = new List<Recipe>();
        // List<Recipe> recipes = GameManager.instance.getRecipes();
        // foreach(Recipe recipe in recipes) {
        //     Debug.Log(recipe.getDrinkName());
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNextDayPress() {
        SceneManager.LoadScene("Store");
    }

    public void onShopPress() {
        shopPanel.SetActive(true);
        menuPanel.SetActive(false);
        makerPanel.SetActive(false);
        reportPanel.SetActive(false);
    }

    public void onMenuPress() {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
        makerPanel.SetActive(false);
        reportPanel.SetActive(false);
    }

    public void onAddPress() {
        shopPanel.SetActive(false);
        menuPanel.SetActive(false);
        makerPanel.SetActive(true);
        reportPanel.SetActive(false);
    }

    public void onSavePress() {
        recipes.Add(new Recipe(nameInput.text, toInt(sugarInput.text), toInt(milkInput.text), toInt(iceInput.text), toInt(teaInput.text), toInt(coffeeInput.text), toFloat(priceInput.text)));
        GameObject newMenu = Instantiate(menuText, menuScrollView);
        Text[] texts = newMenu.GetComponentsInChildren<Text>();
        foreach(Recipe recipe in recipes) {
            foreach(Text text in texts) {
                if(text.name == "Name") {
                    text.text = recipe.getDrinkName();
                }
                else if(text.name == "Price") {
                    text.text = "$" + recipe.getPrice();
                }
            }
        }
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
        makerPanel.SetActive(false);
        reportPanel.SetActive(false);
    }

    public List<Recipe> GetRecipes() {
        return recipes;
    }

    private int toInt(string number) {
        return int.Parse(number);
    }

    private float toFloat(string number) {
        return float.Parse(number);
    }
}
