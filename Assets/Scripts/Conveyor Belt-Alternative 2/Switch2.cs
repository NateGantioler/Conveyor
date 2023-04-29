using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    [Tooltip("Set this to true if it's an intersection")]
    public bool canSwitch;
    [Tooltip("Initial directional tag")]
    public string initialTag;

    private void Start()
    {
        this.gameObject.tag = initialTag;
    }

    private void Update()
    {
        if (canSwitch) { CheckKeys(); }
    }

    void CheckKeys() // checks which keys are pressed
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { SetTag("up"); return; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("down"); return; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { SetTag("left"); return; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SetTag("right"); return; }
    }

    void SetTag(string tag) // sets the tag according to which directional key is pressed
    {
        this.gameObject.tag = tag; 
    }

}
