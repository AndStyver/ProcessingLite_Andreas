using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExample : ProcessingLite.GP21
{
    Ball myBall;

    [SerializeField] int numOfBalls = 10; //how many balls we wanna create
    [SerializeField] Ball[] myBalls; //the array containing our balls

    // Start is called before the first frame update
    void Start()
    {
        myBall = new Ball(5, 5);
       
        myBalls = new Ball[numOfBalls];
        for (int i = 0; i < myBalls.Length; i++)
        {
            myBalls[i] = new Ball(5, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);


        for (int i = 0; i < numOfBalls; i++)
        {
            myBalls[i].MoveBall();
            myBalls[i].Draw();
        }

        myBall.MoveBall();
        myBall.Draw();
    }
}
