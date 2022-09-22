using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExample : ProcessingLite.GP21
{
    Ball myBall;

    // Start is called before the first frame update
    void Start()
    {
        myBall = new Ball(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        myBall.MoveBall();
        myBall.Draw();
    }
}
