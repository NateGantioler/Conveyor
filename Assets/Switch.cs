using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Belt belt;
    [SerializeField] private Belt[] nextBelts;
    [SerializeField] private Color[] nextColors;
    public int nextIndex = 0;

    private void Start() 
    {
        belt = GetComponent<Belt>();
    }

    private void OnMouseDown() 
    {
        Debug.Log("Clicked on Belt");
        nextIndex++;
        Debug.Log("Index: " + nextIndex);
        if(nextIndex >= nextBelts.Length)
        {
            nextIndex = 0;
        }
        belt.nextBelt = nextBelts[nextIndex];
        GetComponent<SpriteRenderer>().color = nextColors[nextIndex];
    }
    
}
