using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public AudioSource audioSource;
    public AudioClip gameOverClip;
    public AudioClip scoreClip;
    public static GameController instance;
    public bool gameOver = false;
    public float scrollSpeed = -100f;
    public int lives = 5;
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
    void Start()
    {
	audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
	livesText.text = "Lives: " + lives;
        if ((gameOver == true) && (Input.GetKey(KeyCode.Space)))
	{
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    }
    void PlaySound(AudioClip clip)
    {
	audioSource.PlayOneShot(clip);
    }
    public void PlayerScored()
    {
	if (gameOver == true)
	{
	    return;   
	}
	score++;
	scoreText.text = "Score: " + score.ToString();
	PlaySound(scoreClip);
    }
    public void PlayerUnalived()
    {
	if (gameOver == true)
	{
	    return;   
	}
	lives--;
	livesText.text = "Lives: " + lives;
	if (lives <= 0)
	{
            PlayerDied();
	}
    }
    public void PlayerDied()
    {
	gameOverText.SetActive(true);
	gameOver = true;
	PlaySound(gameOverClip);
	Debug.Log("Game Over!");
    }
}
