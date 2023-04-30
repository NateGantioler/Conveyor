using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableIntersections : MonoBehaviour
{
    private void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, mousePos);
        
        if(hit.collider != null)
        {
            print("hit something");
            // found hit
            if(hit.collider.tag == "intersection")
            {
                print("hit's tag is intersection");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawLine(this.transform.position, mousePos2);
    }
}
