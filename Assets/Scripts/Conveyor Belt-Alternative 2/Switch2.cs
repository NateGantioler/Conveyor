using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    [Tooltip("Set this to true if it's an intersection")]
    public bool canSwitch;
    [Tooltip("Initial directional tag")]
    public string initialTag;
    
    /*
    private enum SwitchType2
    {
        fourway,
        updownright,
        updownleft,
        upleft,
        upright,
        updown,
        upleftright,
        leftright,
        downleft,
        downright
    }
    [SerializeField] private SwitchType2 swType;
    */

    private void Start()
    {
        this.gameObject.tag = initialTag;
    }

    //public bool[] directions;

    //public List<bool> directions;


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
        Debug.Log("This conveyor has right direction: "+d.right);
    }
    void SetTag(string tag) // sets the tag according to which directional key is pressed
    {
        this.gameObject.tag = tag; 
    }

    /*
    void CheckKeys(SwitchType2 s) // checks which keys are pressed
    {
        switch (s)
        {
            case SwitchType2.fourway:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                if (Input.GetKeyDown(KeyCode.RightArrow)) { SetTag("right"); return; }
                return;
            case SwitchType2.leftright:
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                if (Input.GetKeyDown(KeyCode.RightArrow)) { SetTag("right"); return; }
                return;
            case SwitchType2.updown:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
                return;
            case SwitchType2.updownright:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
                if (Input.GetKeyDown(KeyCode.RightArrow)) { SetTag("right"); return; }
                return;
            case SwitchType2.updownleft:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                return;
            case SwitchType2.upleft:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                return;
            case SwitchType2.upleftright:
                if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                if (Input.GetKeyDown(KeyCode.RightArrow)) { SetTag("right"); return; }
                return;
            case SwitchType2.downleft
                if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
                if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
                return;
        }
        
    }
    */


}
