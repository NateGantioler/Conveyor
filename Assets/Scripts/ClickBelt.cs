using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBelt : MonoBehaviour
{
    private Switch3 switchScript;
    
    private void Start() 
    {
        switchScript = GetComponentInParent<Switch3>();
    }

    private void OnMouseDown() 
    {
        switchScript.ChangeDirection();
    }
}
