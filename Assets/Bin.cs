using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private parcelType binType;
    private Belt belt;
    private Score score;
    
    private void Start() 
    {
        binType = GetComponent<parcelType>();
        belt = GetComponent<Belt>();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<Score>();
    }

    private void Update() 
    {
        if(belt.item != null)
        {
            Item itemScript = belt.item.GetComponent<Item>();
            if(itemScript.itemType.type == binType.type)
            {
                score.AddScore(itemScript.scoreAdd);
            }
            else
            {
                score.DecreaseScore(itemScript.scoreAdd);
            }

            Destroy(belt.item);
        }
    }
}
