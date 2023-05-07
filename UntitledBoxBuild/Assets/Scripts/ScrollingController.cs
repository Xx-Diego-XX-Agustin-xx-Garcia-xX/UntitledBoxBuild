using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour
{
    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
	rigidBody.velocity = new Vector3(0, 0, GameController.instance.scrollSpeed);        
    }
    void Update()
    {
        if (GameController.instance.gameOver == true)
	{
	    rigidBody.velocity = Vector3.zero;
	}
	if (transform.position.z <= 0)
	{
	    Destroy(gameObject);
	}
    }
}
