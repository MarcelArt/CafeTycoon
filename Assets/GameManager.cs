using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {
    OPEN,
    CLOSED
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public Recipe[] recipes;
    public float openTime;
    public RectTransform scrollView;
    public GameObject recipeButton;
    public GameObject managementUI;

    private List<Recipe> recipes;
    private Inventory inventory;
    private float gameTime;
    private GameState state = GameState.CLOSED;
    private ShopManager shopManager;

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
        inventory = GetComponent<Inventory>();
        shopManager = GetComponent<ShopManager>();
        recipes = new List<Recipe>();
        // R = new Recipe("Ice coffee", 3, 1, 3, 0, 1 , 1f);
        // recipes.Add(R);
        // recipes.Add(new Recipe("Ice tea", 3, 0, 3, 1, 0, .5f));
        setRecipeUI();
        // StartCoroutine(selling());
    }

    // Update is called once per frame
    void Update()
    {
        if(state==GameState.OPEN) {
            gameTime = gameTime + Time.deltaTime;
        }
        else {
            gameTime = 0;
        }
    }

    IEnumerator selling() {
        int sold = 0;
        while(gameTime < openTime) {
            Recipe R = recipes[Random.Range(0, recipes.Count)];
            int sellChance = Random.Range(0, 101);
            if(sellChance < calculateLikeness(R)) { // Customer bought
                if(inventory.isAvailable(R)) {
                    inventory.useRecipe(R);
                    Debug.Log(R.getDrinkName() + " sold");
                    sold++;
                }
                else {
                    Debug.Log("No recipe available");
                }
            }
            yield return new WaitForSeconds(.1f);
        }
        
        Debug.Log("Sold: " + sold);
        Debug.Log(inventory.ToString());

        shopManager.updateInvCount();
        managementUI.SetActive(true);
        state = GameState.CLOSED;

        SceneManager.LoadScene("Prep");
    }

    public void startDay() {
        state = GameState.OPEN;
        if(recipes.Count > 0) {
            Debug.Log("Day started");
            managementUI.SetActive(false);
            StartCoroutine(selling());
        }
    }

    public float calculateLikeness(Recipe R) {
        return R.getSweetness() + R.getColdness() + (10 - (R.getPrice() * 2));
    }

    public void setRecipeUI() {
        foreach(Recipe recipe in recipes) {
            GameObject newRecipeButton = Instantiate(recipeButton, scrollView.position, scrollView.rotation, scrollView);
            newRecipeButton.GetComponentInChildren<Text>().text = recipe.getDrinkName() + " ($" + recipe.getPrice() + ")";
        }
    }

    public void addNewRecipe(Recipe newRecipe) {
        recipes.Add(newRecipe);
        int i = recipes.IndexOf(newRecipe);
        GameObject newRecipeButton = Instantiate(recipeButton, scrollView.position, scrollView.rotation, scrollView);
        newRecipeButton.GetComponentInChildren<Text>().text = newRecipe.getDrinkName() + " ($" + newRecipe.getPrice() + ")";
    }

    public List<Recipe> getRecipes() {
        return recipes;
    }
}
