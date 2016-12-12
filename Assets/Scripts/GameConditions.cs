using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditions : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameOver gameOver;

    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null && !isGameOver)
        {
            isGameOver = true;
            ShowGameOverScreen();
        }
	}

    private void ShowGameOverScreen()
    {
        gameOver.gameObject.SetActive(true);
    }

}
