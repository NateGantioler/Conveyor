using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject item;
    public Belt nextBelt;

    public void moveItem()
    {
        if(nextBelt != null)
        {
            item.transform.SetParent(nextBelt.transform);
            item.transform.position = nextBelt.transform.position;
            nextBelt.GetComponent<Belt>().item = item;
            item = null;
        }
        else
        {
            Debug.Log("No belt to push item to");
        }
    }
}
