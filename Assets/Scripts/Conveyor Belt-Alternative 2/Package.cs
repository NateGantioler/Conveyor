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

    // to be later replaced with corresponding sprites
    
    [System.Serializable]
    public struct parcelSprites
    {
        public Sprite red;
        public Sprite green;
        public Sprite blue;
    }
    public parcelSprites sprites;

    private SpriteRenderer SprRenderer;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        SprRenderer = this.GetComponent<SpriteRenderer>();
        
        Random.InitState((int)System.DateTime.Now.Ticks); // makes things more random
        int rand = Random.Range(0,3);
        switch (rand)
        {
            case 0:
                packageColor = "red";
                SprRenderer.sprite = sprites.red;
                return;
            case 1:
                packageColor = "green";
                SprRenderer.sprite = sprites.green;
                return;
            case 2:
                packageColor = "blue";
                SprRenderer.sprite = sprites.blue;
                return;
            case 3:
                Debug.LogError("UNEXPECTED NUMBER");
                return;
        }

    }

    int dir;
    bool collisionDetected;
    bool conveyorIsHacked;

    void Disappear()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("click"))
        {
            if(packageColor == collision.tag)
            {
                // then package has entered the correct end point
                UIManager.AddScore();
                SFXManager.instance.PlaySoundEffect("Chime02");
            }
            else if(packageColor != collision.tag)
            {
                if(collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
                {
                    // package has entered the wrong end point
                    UIManager.SubtractScore();
                    SFXManager.instance.PlaySoundEffect("Bad01");
                }
            }
            // OPTIONAL: check if packages fall off from the conveyor belts by surrounding them with invisible walls
            else if (collision.tag == "outofbounds")
            {
                UIManager.SubtractScore();
                Invoke("Disappear", 0.4f);
            }
            if (collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
            {
                // in any case where the package enters an end point, make it disappear
                Invoke("Disappear", 0.4f);
            }
            // checks the conveyor belt's tag to see which direction it goes
            if (collision.tag == "up")
            {
                conveyorIsHacked = collision.GetComponent<Switch3>().isHacked();
                collisionDetected = true;
                dir = 1;
                return;
            }
            if (collision.tag == "down")
            {
                conveyorIsHacked = collision.GetComponent<Switch3>().isHacked();
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
                conveyorIsHacked = collision.GetComponent<Switch3>().isHacked();
                collisionDetected = true;
                dir = 4;
                return;
            }   
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
        if (!conveyorIsHacked)
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
        else if (conveyorIsHacked)
        {
            switch (dir)
            {
                case 1:
                    rb.velocity = transform.up * speed * 2;
                    return;
                case 2:
                    rb.velocity = -transform.up * speed * 2;
                    return;
                case 3:
                    rb.velocity = -transform.right * speed * 2;
                    return;
                case 4:
                    rb.velocity = transform.right * speed * 2;
                    return;
            }
        }
    }
}
