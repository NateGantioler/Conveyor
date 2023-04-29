using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject item; //Item currently on the Belt
    public Belt nextBelt;   //Belt the Item will move to next

    public void moveItem()
    {
        if(nextBelt != null)
        {
            item.transform.SetParent(nextBelt.transform);               //Sets the item as a child of the conveyor
            item.transform.position = nextBelt.transform.position;      //TODO: needs to be replaced with smooth movement
            nextBelt.GetComponent<Belt>().item = item;                  // Sets the item variable to the item
            item = null;
        }
        else
        {
            Debug.Log("No belt to push item to");   //Error for Level Testing, shouldn't happen in game
        }
    }
}
