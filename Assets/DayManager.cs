using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    private Inventory inventory;
    private List<Recipe> recipes;
    private GameState state = GameState.OPEN;
    private float gameTime = 0f;

    public float openTime;

    private void Awake() {
        inventory = PrepMenuManager.instance.GetComponent<Inventory>();
        recipes = PrepMenuManager.instance.GetRecipes();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selling());
    }

    // Update is called once per frame
    void Update()
    {
        if(state==GameState.OPEN) {
            gameTime = gameTime + Time.deltaTime;
        }
        else {
            gameTime = 0f;
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

        SceneManager.LoadScene("Prep");
    }

    public float calculateLikeness(Recipe R) {
        return R.getSweetness() + R.getColdness() + (10 - (R.getPrice() * 2));
    }
}
