using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
	public Transform[] waypoints;
	int cur = 0;

	public float speed = 0.1f;
	public GameObject Ghost1;
	public GameObject Ghost2;

	void Start()
    {
		Physics2D.IgnoreCollision(Ghost1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(Ghost2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
	void FixedUpdate()
	{
		cur = cur % waypoints.Length;
		// Waypoint not reached yet? then move closer
		if (Vector2.Distance(transform.position, waypoints[cur].position) < 0.1f)
		{
			cur = cur == waypoints.Length ? 0 : cur + 1;
		}
		 //Waypoint reached, select next one
		else {
			Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "Pacman")
			Destroy(co.gameObject);
	}
}
