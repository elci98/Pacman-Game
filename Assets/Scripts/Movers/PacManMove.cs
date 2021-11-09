
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
 
public class PacManMove : MonoBehaviour
{

    public float speed = 0.1f;
    Vector2 dest = Vector2.zero;
    float tiltAroundY = 0f;
    float tiltAroundZ = 0f;


    // Use this for initialization
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up"))
        {
            dest = (Vector2)transform.position + Vector2.up;
            tiltAroundZ = 90f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
        {
            dest = (Vector2)transform.position - Vector2.up;
            tiltAroundZ = -90f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
        {
            dest = (Vector2)transform.position + Vector2.right;
            tiltAroundY = 0f;
            tiltAroundZ = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
        {
            dest = (Vector2)transform.position - Vector2.right;
            tiltAroundY = 180f;
            tiltAroundZ = 0f;
        }
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        Quaternion target = Quaternion.Euler(0, tiltAroundY, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
        GetComponent<Rigidbody2D>().MovePosition(p);


    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
