using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool isGameOver = false;
    public float force;
    public float bound;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isGameOver == false)
	{
	    if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.Space)))
	    {
		rigidBody.velocity = Vector3.zero;
		rigidBody.AddForce(new Vector3(0, force, 0));
	    }
	    else if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
	    {
		rigidBody.AddForce(new Vector3(-force, 0, 0));
	    }
	    else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
	    {
		rigidBody.AddForce(new Vector3(force, 0, 0));
	    }
	}
	if ((transform.position.x > bound) || (transform.position.x < -bound))
        {
	    OnCollisionEnter();
	}
	if ((transform.position.y > bound) || (transform.position.y < -bound))
        {
	    OnCollisionEnter();
	}
	
    }
    void OnCollisionEnter()
    {
	rigidBody.velocity = Vector3.zero;
        isGameOver = true;
	Debug.Log("Game Over!");
	GameController.instance.PlayerDied();
    }
}
