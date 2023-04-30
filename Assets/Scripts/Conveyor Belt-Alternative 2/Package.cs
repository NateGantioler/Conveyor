using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Package : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    int dir;
    bool collisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("click"))
        {
            collisionDetected = true;
            #region tag check
            // checks the conveyor belt's tag to see which direction it goes
            if (collision.tag == "up")
            {
                dir = 1;
                return;
            }
            if (collision.tag == "down")
            {
                dir = 2;
                return;
            }
            if (collision.tag == "left")
            {
                dir = 3;
                return;
            }
            if (collision.tag == "right")
            {
                dir = 4;
                return;
            }
            #endregion
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("click"))
        {
            collisionDetected = false;
        }
    }


    private void Update()
    {
        if (collisionDetected) { Move(); }
    }

    void Move()
    {
        switch (dir)
        {
            case 1:
                rb.velocity = transform.up * speed;
                return;
            case 2:
                rb.velocity = -transform.up * speed;
                return;
            case 3:
                rb.velocity = -transform.right * speed;
                return;
            case 4:
                rb.velocity = transform.right * speed;
                return;
        }
    }
}
