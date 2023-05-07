using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public static GameController instance;
    public bool gameOver = false;
    public float scrollSpeed = -100f;
    private int score = 0;
    void Awake()
    {
	if (instance == null)
	{   
	    instance = this;
	}
	else if (instance != this)
	{
	    Destroy(gameObject);
	}
    }
    void Update()
    {
        if ((gameOver == true) && (Input.GetKey(KeyCode.Space)))
	{
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    }
    public void PlayerScored()
    {
	if (gameOver == true)
	{
	    return;   
	}
	score++;
	scoreText.text = "Score: " + score.ToString();
    }
    public void PlayerDied()
    {
	gameOverText.SetActive(true);
	gameOver = true;
    }
}
