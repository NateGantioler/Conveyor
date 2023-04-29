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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region tag check
        // checks the conveyor belt's tag to see which direction it goes
        if (collision.tag == "up")
        {
            Move(1);
            return;
        }
        if (collision.tag == "down")
        {
            Move(2);
            return;
        }
        if (collision.tag == "left")
        {
            Move(3);
            return;
        }
        if (collision.tag == "right")
        {
            Move(4);
            return;
        }
        #endregion
    }

    void Move(int dir)
    {
        switch (dir)
        {
            case 1:
                rb.velocity = transform.up * speed;
                return;
            case 2:
                rb.velocity = transform.up * speed;
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
