using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMeBallScript : ProcessingLite.GP21
{
    public float x;
    public float y;
    public float diameter;

    private Camera cam;
    Vector2 mousePos;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0); //Clears the background and sets the color to 0.
        StrokeWeight(1);
        Stroke(255);
        Circle(x, y, diameter);

        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        if (Input.GetMouseButton(0))
        {
            //Circle(CircleToMouseVector().x, CircleToMouseVector().y, 0.4f);

            x += CircleToMouseVector().x;
            y += CircleToMouseVector().y;
        }

        Line(mousePos.x, mousePos.y, x, y);
    }

    Vector2 CircleToMouseVector()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        //float deltaX = x - mousePos.x;
        //float deltaY = y - mousePos.y;

        Vector2 _vector = mousePos - new Vector2(x, y);

        if (_vector.magnitude > speed)
        {
            _vector = (mousePos - new Vector2(x, y)).normalized * speed;
        }

        return _vector;
    }
}
