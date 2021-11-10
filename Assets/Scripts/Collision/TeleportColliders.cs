    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportColliders : MonoBehaviour
{
    float yPos = 0.32f;
    float xPos = 7.6f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 newPosition = Vector3.zero;
        if(collider.tag == "LeftCollider")
        {
            newPosition = new Vector3(xPos, yPos, 0);
            GetComponent<Transform>().position = newPosition;
        }

        if (collider.tag == "RightCollider")
        {
            newPosition = new Vector3(-xPos, yPos, 0);
            GetComponent<Transform>().position = newPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
