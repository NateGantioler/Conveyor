using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Package : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    // used to check if package has entered the correct end point
    private string packageColor;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        int rand = Random.Range(0,3);
        switch (rand)
        {
            case 0:
                packageColor = "red";
                return;
            case 1:
                packageColor = "green";
                return;
            case 2:
                packageColor = "blue";
                return;
            case 3:
                Debug.LogError("UNEXPECTED NUMBER");
                return;
        }

    }

    int dir;
    bool collisionDetected;

    void Disappear()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(packageColor == collision.tag)
        {
            // then package has entered the correct end point
            UIManager.AddScore();
            print("AddScore() called");
        }
        else if(packageColor != collision.tag)
        {
            // package has entered the wrong end point
            UIManager.SubtractScore();
            print("SubtractScore() called");
        }
        if(collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
        {
            // in any case where the package enters an end point, make it disappear
            Invoke("Disappear", 0.4f);
        }

        // checks the conveyor belt's tag to see which direction it goes
        if (collision.tag == "up")
        {
            collisionDetected = true;
            dir = 1;
            return;
        }
        if (collision.tag == "down")
        {
            collisionDetected = true;
            dir = 2;
            return;
        }
        if (collision.tag == "left")
        {
            collisionDetected = true;
            dir = 3;
            return;
        }
        if (collision.tag == "right")
        {
            collisionDetected = true;
            dir = 4;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionDetected = false;
    }
    

    private void Update()
    {
        Debug.Log(packageColor);
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
