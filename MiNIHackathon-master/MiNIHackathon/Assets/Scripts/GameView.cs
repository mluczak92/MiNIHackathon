using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour {

    public GameController gameController;
    public GameMenu gameMenu;
    
	// Use this for initialization
	void Start () {
        if (!gameController)
        {
            Debug.LogError("!gameController");
        }
        if (!gameMenu)
        {
            Debug.LogError("!gameMenu");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartClick()
    {
        Debug.Log("GameView::StartClick");

        HideMenu();
        gameController.StartGame();
    }

    public void ShowMenu()
    {
        gameMenu.Show();
    }

    public void HideMenu()
    {
        gameMenu.Hide();
    }
}
