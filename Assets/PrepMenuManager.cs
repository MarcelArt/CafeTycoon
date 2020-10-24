using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepMenuManager : MonoBehaviour
{
    public static PrepMenuManager instance;

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
}
