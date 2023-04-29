using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltManager : MonoBehaviour
{
    public GameObject[] items;
    [SerializeField] private float tickTime = 1f;
    
    void Start()
    {
        Invoke("Tick", tickTime);
    }

    private void Tick()
    {
        Invoke("Tick", tickTime);
        items = GameObject.FindGameObjectsWithTag("item");
        foreach(GameObject item in items)
        {
            item.GetComponent<Item>().moveToNextBelt(); 
        }
    }
}
