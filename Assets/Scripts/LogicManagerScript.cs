using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int score;
    public int health = 3;
    public Text playerScore;
    public bool isAlive = true;
    public GameObject gameOverScreen;
    public HeartDisplay heartDisplay;

    void Start()
    {
        health = DifficultyScript.startHealth;
        heartDisplay = GameObject.FindGameObjectWithTag("Logic").GetComponent<HeartDisplay>();
        heartDisplay.UpdateHealth(health);
    }

    void Update()
    {
        if (health == 0)
        {
            gameOver();
        }
    }

    public void addScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        playerScore.text = score.ToString();
    }

    public void reduceHealth()
    {
        if (health > 0)
        {
            health -= 1;
            heartDisplay.UpdateHealth(health);
        }
    }

    public void addHealth()
    {
        health += 1;
        heartDisplay.UpdateHealth(health);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isAlive = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
