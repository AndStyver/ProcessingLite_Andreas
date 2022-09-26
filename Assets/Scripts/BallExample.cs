using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExample : ProcessingLite.GP21
{
    [SerializeField] int numOfBalls = 10; //how many balls we wanna create
    public Ball[] myBalls; //the array containing our balls at the start
    public List<Ball> ballList; //convert to a list so we can add more later

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
        ballList.AddRange(myBalls);
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
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].Draw();
            ballList[i].MoveBall();
        }
    }

    private void BallCollisions()
    {
        //start at ball[0] check the first ball against every ball after it in the array, jump into the inner loop
        //afterwards, jump out one loop, i goes up one and repeat
        for (int i = 0; i < ballList.Count; i++)
        {
            for (int j = i + 1; j < ballList.Count; j++) //for the current ball, check ball against all after it, then jump out
            {
                if (ballList[i].CircleCollision(ballList[i], ballList[j]))
                {
                    ballList[i].ballVel *= -1;
                    ballList[j].ballVel *= -1;
                }
            }
        }
    }
}
