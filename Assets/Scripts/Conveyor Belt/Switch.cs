using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private enum SwitchType
    {
        Dir2,
        Dir4
    } 
    [SerializeField] private SwitchType type;

    private void OnMouseDown() //When clicking on the switching Belt it switches to the next destination belt in the Array
    {   
        switch(type)
        {
            case SwitchType.Dir2:
                transform.Rotate(0,0,180);
                break;
            case SwitchType.Dir4:
                transform.Rotate(0,0,90);
                break;
            default:
                Debug.LogWarning("Switch Type Problem");
                break;
        }
    }
}
