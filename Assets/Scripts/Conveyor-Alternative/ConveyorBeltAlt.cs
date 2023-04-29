using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltAlt : MonoBehaviour
{
    
    // package gameobject (can only move one package at a time)
    public float speed;

    private bool packageOnTop;
    private Rigidbody2D packageRB;

    private float distance;

    // checks if it's colliding with a package's trigger type collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        packageRB = collision.GetComponent<Rigidbody2D>();
        
        // calculates distance between conveyor belt and package
        distance = Vector3.Distance(this.transform.position, collision.GetComponent<Transform>().position);
        Debug.Log($"Distance is {distance}");

        //checks if package is close to the center before making object move
        if (distance <= 0.1f)
        {
            packageOnTop = true;
        }
       
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(distance > 0.1f)
        {
            packageOnTop = false;
            return;
        }
        packageOnTop = false;
    }
    
    private void FixedUpdate()
    {
        if (packageOnTop)
        {
            MovePackage();
        }
        if (distance > 0.1f)
        {
            packageOnTop = false;
        }
    }

    private void MovePackage()
    {
        packageRB.velocity = transform.right * speed;
    }

}
