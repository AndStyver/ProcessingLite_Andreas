using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameoverText;
    public bool gameoverBool;

    // Start is called before the first frame update
    void Start()
    {
        gameoverBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverBool)
        {
            Time.timeScale = 0;
            gameoverText.SetActive(true);

            Restart();
        }
        else
        {
            Time.timeScale = 1;
            gameoverText.SetActive(false);
        }
    }

    private void Restart()
    {
        if (Input.GetKey(KeyCode.R))
        {

        }
    }
}
