using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    [SerializeField] float speedModifier;

    public Zombie(float _x, float _y, float _zombieSize) : base(_x, _y, _zombieSize)
    {
        
        //charPos = new Vector2(_x, _y);

        //charVel = new Vector2();
        //charVel.x = Random.Range(-5f, 5f);
        //charVel.y = Random.Range(-5f, 5f);

        //charSize = _zombieSize;
    }

    public override void UpdateCharacters()
    {
        charPos += charVel * 0.5f * Time.deltaTime;

        if (charPos.x < 0) { charPos.x = Width; }
        else if (charPos.x > Width) { charPos.x = 0; }
        if (charPos.y < 0) { charPos.y = Height; }
        else if (charPos.y > Height) { charPos.y = 0; }
    }
}