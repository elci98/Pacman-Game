using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDotDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Pacman")
            Destroy(gameObject);
    }
}
