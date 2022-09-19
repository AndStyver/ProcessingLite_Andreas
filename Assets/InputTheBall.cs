using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTheBall : ProcessingLite.GP21
{
    float posX;
    float posY;
    public float diameter;
    public float ballSpeed;

    float v = 1;
    int a = 1;

    public bool gravity;

    // Start is called before the first frame update
    void Start()
    {
        posX = Width / 2;
        posY = Height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        v += a * Time.deltaTime; //constant acceleration

        posX += Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime;


        if (gravity) { posY += -v * Time.deltaTime; }
        else { posY += Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.G)) { gravity = !gravity; }

        Circle(posX, posY, diameter);
    }
}
