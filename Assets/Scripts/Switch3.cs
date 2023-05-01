using UnityEngine;

public class Switch3 : MonoBehaviour
{
    //Different Directions
    private enum direction {up, right, down, left}

    //currentDirection is also the starting direction
    [SerializeField] private direction currentDirection;

    //To choose in the inspector which directions should be availible
    //In the inspector they are wirtten as Element 1-4, they are in clockwise order so up, right, down, left
    [SerializeField] private bool[] enabledDirectons = new bool[] { true, true, true, true };


    // using randomly generated numbers
    // to determine if this conveyor belt will be hacked


    public bool isHacked()
    {
        int rand = Random.Range(0, 15);
        if (rand == 1) { print(this.gameObject.name+" HACKED"); return true; }
        else { Invoke("isHacked", 1f); print(this.gameObject.name+" NOT HACKED"); return false; }
    }
    


    private void Start() 
    {
        SetTag(currentDirection.ToString());
        Invoke("isHacked", 1f);
    }

    public void ChangeDirection()
    {
        int nextDirection = (int)currentDirection;  //enum to int

        do  //Checks thorugh all Directions until it find one that is enabled
        {   
            nextDirection = (nextDirection + 1) % 4;
        } 
        while (!enabledDirectons[nextDirection]);

        // Update the current option
        currentDirection = (direction)nextDirection;    //int to enum
        SetTag(currentDirection.ToString());
    }

    void SetTag(string tag) // sets the tag according to which directional key is pressed
    {
        this.gameObject.tag = tag; 
    }
}