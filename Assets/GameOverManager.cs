using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : ProcessingLite.GP21
{
    [SerializeField] GameObject gameoverText;
    public bool gameoverBool; //true if game is over, false if the player is alive

    BallExample ballManager;
    InputTheBall playerManager;

    // Start is called before the first frame update
    void Start()
    {
        gameoverBool = false;
        ballManager = GetComponent<BallExample>();
        playerManager = GetComponent<InputTheBall>();
        Background(255);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverBool)
        {
            Time.timeScale = 0;
            TextSize(50);
            Text("You died: Hit R to restart", Width / 2, Height / 2);

            //gameoverText.SetActive(true);

            Restart();
        }
        else
        {
            Time.timeScale = 1;
            //gameoverText.SetActive(false);
        }
    }

    private void Restart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Background(255);
            ballManager.GenerateBalls();
            playerManager.ResetGame();

            gameoverBool = false;
        }
    }
}
