using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public float position;
    public float frequency;
    public float timer;
    public float rangeMin;
    public float rangeMax;
    void Update()
    {
        if (GameController.instance.gameOver == false)
	{
	    timer -= Time.deltaTime;
	    if (timer <= 0)
	    {
	       position = Random.Range(rangeMin, rangeMax);
	       transform.position = new Vector3(position, position, 25);
	       Instantiate(obstacle, transform.position, transform.rotation);
	       timer = frequency;
	    }
	}
	if (player != null)
	{
	    Time.timeScale = 1.25f;
	}
	else
	{
	    Time.timeScale = 0;
	}
    }
}
