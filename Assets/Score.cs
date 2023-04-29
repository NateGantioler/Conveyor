using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score = 0;

    public void AddScore(float _score)
    {
        score += _score;
        Debug.Log("Added Score: " + _score);
    }

    public void DecreaseScore(float _score)
    {
        _score /= 2;
        score -= (_score);
        Debug.Log("Decreased Score: " + _score);
    }
}
