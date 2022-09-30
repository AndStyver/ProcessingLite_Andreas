using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AndSty : IRandomWalker
{
    //Add your own variables here.
    //Do not use processing variables like width or height

    Vector2 pVector;

    int direction = 0;
    readonly List<float> biases = new List<float>(4);
    float diceRoll;

    int areaWidth;
    int areaHeight;

    public string GetName()
    {
        return "AndreasS"; //When asked, tell them our walkers name
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        for (int i = 0; i < 4; i++) { biases.Add(0.25f); } //sets all biases to be equally likely to start

        areaWidth = playAreaWidth;
        areaHeight = playAreaHeight;

        //Select a starting position or use a random one.
        //float x = (int)UnityEngine.Random.Range(0, playAreaWidth);
        float y = (int)UnityEngine.Random.Range(0, playAreaHeight);
        float x = playAreaWidth;
        //float y = playAreaHeight;

        //a PVector holds floats but make sure its whole numbers that are returned!
        pVector = new Vector2(x, y);
        return pVector;
    }

    public Vector2 Movement()
    {
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.

        UpdateBiases();

        switch (WeightedDecision())
        {
            case 0:
                pVector.x += 1;
                return new Vector2(1, 0);
            case 1:
                pVector.x -= 1;
                return new Vector2(-1, 0);
            case 2:
                pVector.y += 1;
                return new Vector2(0, 1);
            default:
                pVector.y -= 1;
                return new Vector2(0, -1);
        }
    }

    int WeightedDecision()
    {
        direction = (int)UnityEngine.Random.Range(0, 4);
        diceRoll = UnityEngine.Random.Range(0, 1f);
        int selectedDirection = direction;

        double cumulative = 0.0;
        for (int i = 0; i < biases.Count; i++)
        {
            cumulative += biases[i];
            //Debug.Log("During step " + i + " cumulative is " + cumulative + " While diceRoll was " + diceRoll);
            if (diceRoll < cumulative)
            {
                selectedDirection = i;
                break;
            }
        }

        return selectedDirection;
    }

    void UpdateBiases()
    {
        if (pVector.x >= areaWidth - 1)
        {
            biases[0] = 0f;
            biases[1] = 0.2f;
            biases[2] = 0.4f;
            biases[3] = 0.4f;
            return;
        }
        else if (pVector.x <= 1)
        {
            biases[0] = 0.2f;
            biases[1] = 0f;
            biases[2] = 0.4f;
            biases[3] = 0.4f;
            return;
        }

        if (pVector.y >= areaHeight - 1)
        {
            biases[0] = 0.4f;
            biases[1] = 0.4f;
            biases[2] = 0f;
            biases[3] = 0.2f;
            return;
        }
        else if (pVector.y <= 1)
        {
            biases[0] = 0.4f;
            biases[1] = 0.4f;
            biases[2] = 0.2f;
            biases[3] = 0f;
            return;
        }

        switch (WeightedDecision())
        {
            case 0:
                biases[0] = 0.3f;
                biases[1] = 0.1f;
                biases[2] = 0.3f;
                biases[3] = 0.3f;
                break;
            case 1:
                biases[0] = 0.1f;
                biases[1] = 0.3f;
                biases[2] = 0.3f;
                biases[3] = 0.3f;
                break;
            case 2:
                biases[0] = 0.3f;
                biases[1] = 0.3f;
                biases[2] = 0.3f;
                biases[3] = 0.1f;
                break;
            default:
                biases[0] = 0.3f;
                biases[1] = 0.3f;
                biases[2] = 0.1f;
                biases[3] = 0.3f;
                break;
        }
        //Debug.Log("bias 0: " + biases[0] + ", bias 1: " + biases[1] + ", bias 2: " + biases[2] + ", bias 3: " + biases[3]);
    }
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!