using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    // set this to true if it's an intersection
    public bool canSwitch;

    // directions the intersection has
    private enum initTag { up,down,left,right }
    [SerializeField] private initTag initialTag;

    [SerializeField] public static Color lightOFF;
    [SerializeField] public static Color lightON;

    private SpriteRenderer[] renderers;

    private void Start()
    {
        renderers = this.GetComponentsInChildren<SpriteRenderer>();
        this.gameObject.tag = ""+initialTag;
    }

    [System.Serializable]
    public struct directions
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    public directions possibleDirections;

    

    private void Update()
    {
        if (canSwitch) { CheckKeys(possibleDirections); }
    }

    void CheckKeys(directions d) // checks which keys are pressed
    {
        if (d.up)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetTag("up");
            }
        }
        if (d.down)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetTag("down");
            }
        }
        if (d.left)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetTag("left");
            }
        }
        if (d.right)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetTag("right");
            }
        }
        Debug.Log("This conveyor has down direction: "+d.down);
    }
    void SetTag(string tag) // sets the tag according to which directional key is pressed
    {
        this.gameObject.tag = tag; 
    }


}
