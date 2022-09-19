using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTheBall : ProcessingLite.GP21
{
    float posX;
    public float diameter;
    public float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        posX = Width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        posX += Input.GetAxis("Horizontal") * ballSpeed;
        Circle(posX, Height / 2, diameter);
    }
}
