using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{    
    public parcelType itemType;
    public float scoreAdd;
    
    private void Start() 
    {
        itemType = GetComponent<parcelType>();
    }

    public void moveToNextBelt()
    {
        GetComponentInParent<Belt>().moveItem();
    }
}
