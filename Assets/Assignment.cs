using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : ProcessingLite.GP21
{
    [Header("Circle")]
    public float x;
    public float y;
    public float diameter = 0.2f;

    Camera cam;

    [Header("Scanlines")]
    public float spaceBetweenLines;
    public float strokeWeight;

    [Header("Parabola")]
    public float numOfLinesParabola;
    public float paraX1;
    public float paraY1;
    public float paraX2;
    public float paraY2;
    public float paraX3;
    public float paraY3;

    public float sX; //x coordinate for the S
    public float sY; //y coordinate for the S
    public float sSize = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        Line(4, 7, 4, 3);
        Line(4, 5, 6, 5);
        Line(6, 7, 6, 3);

        Line(8, 5.5f, 8, 3);
        Line(8, 7, 8, 6.8f);

        Triangle(RandomVector(), RandomVector(), RandomVector());
    }

    // Update is called once per frame
    void Update()
    {
        Background(0); //Clears the background and sets the color to 0.
        StrokeWeight(1);
        Stroke(255);
        Circle(x, y, diameter);

        //The first A
        Triangle(new Vector2(4, 8), new Vector2(3, 6), new Vector2(5, 6));

        //The n
        Line(6, 7, 6, 6);
        Line(6, 6.7f, 6.6f, 6.7f);
        Line(6.6f, 6.7f, 6.6f, 6);

        //The d
        Circle(7.5f, 6.35f, 0.7f);
        Line(7.9f, 7.3f, 7.9f, 6);

        //The R
        Line(8.5f, 6.8f, 8.5f, 6);
        Circle(8.6f, 6.6f, 0.4f);
        Line(8.5f, 6.45f, 8.9f, 6);

        //The e
        Quad(9.4f, 6.65f, 9.8f, 6.65f, 9.8f, 6.3f, 9.4f, 6.3f);
        Line(9.4f, 6.3f, 9.4f, 6);
        Line(9.4f, 6, 9.8f, 6);

        //the second A
        Triangle(new Vector2(10.5f, 6.6f), new Vector2(10.3f, 6), new Vector2(10.7f, 6));

        DrawS(new Vector2(sX, sY));

        //scanlines
        if (spaceBetweenLines <= 0) { spaceBetweenLines = 0.1f; }

        StrokeWeight(strokeWeight);
        Stroke(128, 128, 128, 64);

        for (int i = 0; i < (Height / spaceBetweenLines); i++)
        {
            Line(0, spaceBetweenLines * i, Width, spaceBetweenLines * i);
        }

        //parabola
        StrokeWeight(1);
        Stroke(255);
        Line(paraX1, paraY1, paraX2, paraY2);
        Line(paraX2, paraY2, paraX3, paraY3);


        StrokeWeight(1f);
        Stroke(125);

        if (numOfLinesParabola <= 0) { numOfLinesParabola = 0.1f; }
        //print(Mathf.Sqrt((paraX2 - paraX1) + (paraY2 - paraY1)) / numOfLinesParabola);
        for (int i = 0; i < numOfLinesParabola; i++)
        {
            Line(0, Height - spaceBetweenLines * i, Width * i / (Height / spaceBetweenLines), 0);

            if (i % 3 == 0)
            {
                Stroke(255, 0, 0, 125);
            }
            else
            {
                Stroke(125);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

            x = mousePos.x;
            y = mousePos.y;
        }

        ParabolaInputs();
    }

    void ParabolaInputs()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            paraX1 = mousePos.x;
            paraY1 = mousePos.y;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            paraX2 = mousePos.x;
            paraY2 = mousePos.y;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            paraX3 = mousePos.x;
            paraY3 = mousePos.y;
        }

    }

    private void DrawS(Vector2 _center)
    {
        StrokeWeight(sSize);
        //the s
        Line(-sSize / 2 + _center.x, sSize + _center.y, sSize / 2 + _center.x, sSize + _center.y);
        Line(-sSize / 2 + _center.x, sSize + _center.y, -sSize / 2 + _center.x, _center.y);
        Line(-sSize / 2 + _center.x, _center.y, sSize / 2 + _center.x, _center.y);
        Line(sSize / 2 + _center.x, _center.y, sSize / 2 + _center.x, -sSize + _center.y);
        Line(sSize / 2 + _center.x, -sSize + _center.y, -sSize / 2 + _center.x, -sSize + _center.y);

        //orignal Coordinates
        // Line(11.6f + _center.x, 6.6f + _center.y, 11.2f + _center.x, 6.6f + _center.y);
        //Line(11.2f, 6.6f, 11.2f, 6.3f);
        //Line(11.2f, 6.3f, 11.6f, 6.3f);
        //Line(11.6f, 6.3f, 11.6f, 6);
        //Line(11.6f, 6, 11.2f, 6);
    }

    Vector2 RandomVector()
    {
        Vector2 vector = new(Random.Range(0, 22), Random.Range(0, 10));

        return (vector);
    }
}
