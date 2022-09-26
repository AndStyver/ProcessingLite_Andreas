using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ProcessingLite.GP21
{
    public Vector2 charPos; //POSition of our ball
    public Vector2 charVel; //VELocity of our ball
    public float charSize;

    public Character()
    {

    }

    public Character(float _x, float _y, float _size)
    {
        charPos = new Vector2(_x, _y);

        charVel = new Vector2();
        charVel.x = Random.Range(-5f, 5f);
        charVel.y = Random.Range(-5f, 5f);

        charSize = _size;
    }

    public void Draw(int _r, int _g, int _b)
    {
        Stroke(_r, _g, _b);
        StrokeWeight(0.5f);
        Circle(charPos.x, charPos.y, charSize);
    }

    public virtual void UpdateCharacters()
    {
        charPos += charVel * Time.deltaTime;

        if (charPos.x < 0) { charPos.x = Width; }
        else if (charPos.x > Width) { charPos.x = 0; }
        if (charPos.y < 0) { charPos.y = Height; }
        else if (charPos.y > Height) { charPos.y = 0; }
    }

    public bool CircleCollision(Character _char1, Character _char2)
    {
        float maxDistance = _char1.charSize / 2 + _char2.charSize / 2;

        if (Mathf.Abs(_char1.charPos.x - _char2.charPos.x) > maxDistance || Mathf.Abs(_char1.charPos.y - _char2.charPos.y) > maxDistance)
        { return false; }

        else if (Vector2.Distance(new(_char1.charPos.x, _char1.charPos.y), new(_char2.charPos.x, _char2.charPos.y)) > maxDistance)
        { return false; }
        else { return true; }
    }
}
