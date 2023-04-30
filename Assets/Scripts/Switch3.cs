using UnityEngine;

public class Switch3 : MonoBehaviour
{
    //Different Directions
    private enum direction { Up, Right, Down, Left }

    //currentDirection is also the starting direction
    [SerializeField] private direction currentDirection;

    //To choose in the inspector which directions should be availible
    //In the inspector they are wirtten as Element 1-4, they are in clockwise order so up, right, down, left
    [SerializeField] private bool[] enabledDirectons = new bool[] { true, true, true, true };

    private void OnMouseDown()
    {
        int nextDirection = (int)currentDirection;  //enum to int

        do  //Checks thorugh all Directions until it find one that is enabled
        {   
            nextDirection = (nextDirection + 1) % 4;    
        } 
        while (!enabledDirectons[nextDirection]);

        // Update the current option
        currentDirection = (direction)nextDirection;    //int to enum
        Debug.Log(currentDirection);
    }
}