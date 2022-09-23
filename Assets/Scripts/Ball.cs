using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    Vector2 ballPos; //POSition of our ball
    public Vector2 ballVel; //VELocity of our ball
    public float ballSize;

    public Ball(float _x, float _y, float _size)
    {
        ballPos = new Vector2(_x, _y);

        ballVel = new Vector2();
        ballVel.x = Random.Range(-5f, 5f);
        ballVel.y = Random.Range(-5f, 5f);

        ballSize = _size;
    }

    public void Draw()
    {
        Stroke(255, 0, 0);
        StrokeWeight(0.5f);
        Circle(ballPos.x, ballPos.y, ballSize);
    }

    public void MoveBall()
    {
        ballPos += ballVel * Time.deltaTime;

        if (ballPos.x < 0 || ballPos.x > Width) { ballVel.x *= -1; }
        if (ballPos.y < 0 || ballPos.y > Height) { ballVel.y *= -1; }
    }

    public bool CircleCollision(Ball _ball1, Ball _ball2)
    {
        float maxDistance = _ball1.ballSize / 2 + _ball2.ballSize / 2;

        if (Mathf.Abs(_ball1.ballPos.x - _ball2.ballPos.x) > maxDistance || Mathf.Abs(_ball1.ballPos.y - _ball2.ballPos.y) > maxDistance)
        {
            return false;
        }

        else if (Vector2.Distance(new Vector2(_ball1.ballPos.x, _ball1.ballPos.y), new(_ball2.ballPos.x, _ball2.ballPos.y)) > maxDistance)
        {
            return false;
        }
        else { return true; }
    }
}
