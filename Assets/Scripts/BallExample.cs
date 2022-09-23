using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExample : ProcessingLite.GP21
{
    [SerializeField] int numOfBalls = 10; //how many balls we wanna create
    [SerializeField] Ball[] myBalls; //the array containing our balls

    // Start is called before the first frame update
    void Start()
    {
        myBalls = new Ball[numOfBalls];
        for (int i = 0; i < myBalls.Length; i++)
        {
            myBalls[i] = new Ball(Random.Range(0, Width), Random.Range(0, Height), Random.Range(0.2f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        for (int i = 0; i < numOfBalls; i++)
        {
            myBalls[i].Draw();
            myBalls[i].MoveBall();
        }

        //start at ball[0] check the first ball against every ball after it in the array
        //afterwards, jump out one loop, go up one and repeat
        for (int i = 0; i < myBalls.Length; i++)
        {
            for (int j = i + 1; j < myBalls.Length; j++) //
            {
                if (myBalls[i].CircleCollision(myBalls[i], myBalls[j]))
                {
                    myBalls[i].ballVel *= -1;
                    myBalls[j].ballVel *= -1;
                }
            }
        }

    }
}
