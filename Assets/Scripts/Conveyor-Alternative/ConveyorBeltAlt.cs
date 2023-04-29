using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltAlt : MonoBehaviour
{
    
    // package gameobject (can only move one package at a time)
    public float speed;

    private bool packageOnTop;
    public Rigidbody2D packageRB;

    // checks if it's colliding with a package's trigger type collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        packageRB = collision.GetComponent<Rigidbody2D>();
        packageOnTop = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        packageOnTop = false;
        packageRB.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        if (packageOnTop)
        {
            MovePackage();
        }
    }

    private void MovePackage()
    {
        packageRB.velocity = transform.right * speed;
    }

}
