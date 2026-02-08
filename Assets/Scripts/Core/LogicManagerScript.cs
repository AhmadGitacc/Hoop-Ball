using System.IO;
using System.Linq;
using TMPro;
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
    public TextMeshProUGUI leaderboardText;

    private string savePath;
    private LeaderboardList leaderboardData = new LeaderboardList();
    private bool isGameOver = false;

    void Start()
    {
        health = MenuManagerScript.startHealth;
        heartDisplay = GameObject.FindGameObjectWithTag("Logic").GetComponent<HeartDisplay>();
        heartDisplay.UpdateHealth(health);
        savePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
    }

    void Update()
    {
        if (health == 0 && !isGameOver)
        {
            gameOver();
            isGameOver = true;
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
        string nameToSave = MenuManagerScript.playerName;

        leaderboardData.entries.Add(new HighScoreEntry { playerName = nameToSave, score = score });
        leaderboardData.entries = leaderboardData.entries.OrderByDescending(e => e.score).Take(5).ToList();

        string json = JsonUtility.ToJson(leaderboardData);
        File.WriteAllText(savePath, json);

        UpdateLeaderboardUI();
    }

    void UpdateLeaderboardUI()
    {
        leaderboardText.text = "TOP 5 SCORES:\n";
        foreach (var entry in leaderboardData.entries)
        {
            leaderboardText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }

    void LoadLeaderboard()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            leaderboardData = JsonUtility.FromJson<LeaderboardList>(json);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
