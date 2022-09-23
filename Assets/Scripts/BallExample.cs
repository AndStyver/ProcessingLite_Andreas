using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExample : ProcessingLite.GP21
{
    [SerializeField] int numOfBalls = 10; //how many balls we wanna create
    public Ball[] myBalls; //the array containing our balls

    // Start is called before the first frame update
    void Start()
    {
        myBalls = new Ball[numOfBalls];
        GenerateBalls();
    }

    public void GenerateBalls()
    {
        for (int i = 0; i < myBalls.Length; i++)
        {
            myBalls[i] = new Ball(Random.Range(0, Width), Random.Range(0, Height), Random.Range(0.2f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Background(255);
        DrawBalls();

        BallCollisions();
    }

    public void DrawBalls()
    {
        for (int i = 0; i < numOfBalls; i++)
        {
            myBalls[i].Draw();
            myBalls[i].MoveBall();
        }
    }

    private void BallCollisions()
    {
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
