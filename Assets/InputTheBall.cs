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
    float a = 1; //acceleration of gravity
    public float weight; //how much the ball is affected by gravity

    public bool gravity;
    [SerializeField] float acceleration; //acceleration in movement

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


        if (Input.GetAxis("Horizontal") != 0)
        {
            acceleration += Time.deltaTime;
            posX += Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime * acceleration;
        }
        else
        {
            if (acceleration > 0)
                acceleration -= Time.deltaTime;
        }

        //if gravity is on, fall down
        if (gravity)
        {
            posY += a * Time.deltaTime;
            a -= Time.deltaTime * weight;
        }
        else
        {
            posY += Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gravity = !gravity;
            a = 0;
        } //toggle on/off gravity with g

        Circle(posX, posY, diameter);
    }
}
