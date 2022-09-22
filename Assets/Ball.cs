using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    Vector2 ballPos; //POSition of our ball
    Vector2 ballVel; //VELocity of our ball

    public Ball(float _x, float _y)
    {
        ballPos = new Vector2(_x, _y);

        ballVel = new Vector2();
        ballVel.x = Random.Range(1, 10) - 5;
        ballVel.y = Random.Range(1, 10) - 5;
    }

    public void Draw()
    {
        Circle(ballPos.x, ballPos.y, 0.5f);
    }

    public void MoveBall()
    {
        ballPos += ballVel * Time.deltaTime;
    }
}
