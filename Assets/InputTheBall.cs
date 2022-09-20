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
    [SerializeField] float verAcceleration; //acceleration of vertical movement
    [SerializeField] float maxSpeed = 3; //maxSpeed of the ball

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

        HorizontalMovement();
        VerticalMovement();

        Gravity();

        ScreenWrap();

        Circle(posX, posY, diameter);
    }

    private void HorizontalMovement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && acceleration <= maxSpeed)
        {
            acceleration += Time.deltaTime;
            posX += Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime * acceleration;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && acceleration >= -maxSpeed)
        {
            acceleration -= Time.deltaTime;
            posX -= Input.GetAxis("Horizontal") * ballSpeed * Time.deltaTime * acceleration;
        }
        else
        {
            if (acceleration > 0)
                acceleration -= Time.deltaTime;
            else if (acceleration < 0)
                acceleration += Time.deltaTime;

            posX += ballSpeed * Time.deltaTime * acceleration;
        }

        if (0 + acceleration < 0.01f && 0 - acceleration < 0.01f) { acceleration = 0; }
    }

    void VerticalMovement()
    {
        //if gravity is on, fall down
        if (gravity)
        {
            posY += a * Time.deltaTime;
            a -= Time.deltaTime * weight;
        }
        else //else move with arrowkeys
        {
            if (Input.GetAxisRaw("Vertical") > 0 && verAcceleration <= maxSpeed)
            {
                verAcceleration += Time.deltaTime;
                posY += Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime * verAcceleration;
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && verAcceleration >= -maxSpeed)
            {
                verAcceleration -= Time.deltaTime;
                posY -= Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime * verAcceleration;
            }
            else
            {
                if (verAcceleration > 0)
                    verAcceleration -= Time.deltaTime;
                else if (verAcceleration < 0)
                    verAcceleration += Time.deltaTime;

                posY += ballSpeed * Time.deltaTime * verAcceleration;
            }

            if (0 + verAcceleration < 0.01f && 0 - verAcceleration < 0.01f) { verAcceleration = 0; }
            //posY += Input.GetAxis("Vertical") * ballSpeed * Time.deltaTime;
        }
    }

    private void Gravity()
    {
        //toggle on/off gravity with g
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravity = !gravity;
            a = 0;
        }
    }

    void ScreenWrap()
    {
        if (posX < 0) { posX = Width; }
        if (posX > Width) { posX = 0; }

        if (posY > Height) { posY = Height; }
        if (posY < 0) { posY = 0; }
    }
}
