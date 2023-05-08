using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
	{
	    GameController.instance.PlayerScored();
	}
    }
}
