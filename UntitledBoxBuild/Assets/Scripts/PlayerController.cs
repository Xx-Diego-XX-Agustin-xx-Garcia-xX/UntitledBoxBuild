using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool isGameOver = false;
    public AudioClip jumpClip;
    public float force;
    public float bound;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isGameOver == false)
	{
	    if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.Space)))
	    {
		rigidBody.velocity = Vector3.zero;
		rigidBody.AddForce(new Vector3(0, force, 0));
		PlaySound(jumpClip);
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
	    isGameOver = true;
	    Debug.Log("Game Over!");
	    GameController.instance.PlayerDied();
	}
	else if ((transform.position.y > bound) || (transform.position.y < -bound))
        {
	    isGameOver = true;
	    Debug.Log("Game Over!");
	    GameController.instance.PlayerDied();
	}
	
    }
    void PlaySound(AudioClip clip)
    {
	audioSource.PlayOneShot(clip);
    }
    void OnCollisionEnter()
    {
	if (GameController.instance.lives < 0)
	{
            rigidBody.velocity = Vector3.zero;
            isGameOver = true;
	    GameController.instance.PlayerDied();
	}
	else
	{
	    GameController.instance.PlayerUnalived();
	}
    }
}
