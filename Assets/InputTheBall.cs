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
    public bool gravityBool;

    [SerializeField] float acceleration; //acceleration in movement
    [SerializeField] float verAcceleration; //acceleration of vertical movement
    [SerializeField] float maxSpeed = 3; //maxSpeed of the ball
    int horMovDir; //horizontal moement direction 1 for right, - 1 for left
    int verMovDir; //vertical movement direction 1 for up, -1 for down
    Vector2 movementVector;

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
        StrokeWeight(2);

        HorizontalMovement();
        VerticalMovement();

        Gravity();

        ScreenWrap();
        ScreenPeek();

        Circle(posX, posY, diameter);
    }

    private void HorizontalMovement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && acceleration <= maxSpeed)
        {
            acceleration += Time.deltaTime;
            posX += Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime * acceleration;
            horMovDir = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && acceleration <= maxSpeed)
        {
            acceleration += Time.deltaTime;
            posX -= Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime * -acceleration;
            horMovDir = -1;
        }
        else
        {
            if (acceleration > 0) { acceleration -= Time.deltaTime; }
            posX += ballSpeed * Time.deltaTime * acceleration * horMovDir;
        }

        //if (0 + acceleration < 0.01f && 0 - acceleration < 0.01f) { acceleration = 0; }
    }

    void VerticalMovement()
    {
        //if gravity is on, fall down
        if (gravityBool)
        {
            a -= Time.deltaTime * weight;
            posY += a * Time.deltaTime;

            if (posY < 0)
            {
                a *= -0.95f;
            }
            return;
        }

        //else move with arrowkeys
        if (Input.GetAxisRaw("Vertical") > 0 && verAcceleration <= maxSpeed)
        {
            verAcceleration += Time.deltaTime;
            posY += Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime * verAcceleration;
            verMovDir = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && verAcceleration <= maxSpeed)
        {
            verAcceleration += Time.deltaTime;
            posY -= Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime * -verAcceleration;
            verMovDir = -1;
        }
        else
        {
            if (verAcceleration > 0)
                verAcceleration -= Time.deltaTime;

            posY += ballSpeed * Time.deltaTime * verAcceleration * verMovDir;
        }
    }

    private void Gravity()
    {
        //toggle on/off gravity with g
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityBool = !gravityBool;
            a = 0;
            verAcceleration = 0;
        }
    }

    void ScreenWrap()
    {
        if (posX < 0) { posX = Width; }
        if (posX > Width) { posX = 0; }

        if (posY > Height) { posY = Height; }
        if (posY < 0) { posY = 0; }
    }

    void ScreenPeek()
    {
        if (posX - diameter < 0)
        {
            Circle(posX + Width, posY, diameter);
            //Debug.Log("Should peek right");
        }
        if (posX + diameter > Width)
        {
            Circle(posX - Width, posY, diameter);
            //Debug.Log("Should peek left");
        }
    }
}
