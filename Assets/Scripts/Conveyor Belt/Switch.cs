using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Belt belt;
    [SerializeField] private Belt[] nextBelts;  //Array for the possible next belts
    [SerializeField] private Color[] nextColors;    //will be replaced with brick's art
    public int nextIndex = 0;

    private void Start() 
    {
        belt = GetComponent<Belt>();
    }

    private void OnMouseDown() //When clicking on the switching Belt it switches to the next destination belt in the Array
    {
        nextIndex++;
        if(nextIndex >= nextBelts.Length)
        {
            nextIndex = 0;
        }
        belt.nextBelt = nextBelts[nextIndex];
        GetComponent<SpriteRenderer>().color = nextColors[nextIndex];
    }
    
}
