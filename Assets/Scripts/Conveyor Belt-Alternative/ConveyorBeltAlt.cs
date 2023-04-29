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

    private Transform packageTransform;

    // checks if it's colliding with a package's trigger type collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        packageRB = collision.GetComponent<Rigidbody2D>();

        packageTransform = collision.GetComponent<Transform>();
        
        packageOnTop = true;
    }
    
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(distance > 0.1f)
        {
            packageOnTop = false;
            return;
        }
        packageOnTop = false;
        packageRB.velocity = new Vector2(0, 0);
    }
    */

    private void FixedUpdate()
    {
        distance = Vector3.Distance(this.transform.position, packageTransform.position);
        Debug.Log($"Distance is {distance}");

        if (packageOnTop && distance <= 0.5f)
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
