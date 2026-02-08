using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public static float hoopSpeed = 1;
    public static int spawnRate = 3;
    public static int startHealth = 3;
    public TMP_InputField playerNameInput;
    public static string playerName = "Guest";

    void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(playerNameInput.text))
        {
            playerName = playerNameInput.text;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void EasyMode()
    {
        hoopSpeed = 1f;
        startHealth = 3;
        spawnRate = 5;
        StartGame();
    }

    public void MidMode()
    {
        hoopSpeed = 2f;
        startHealth = 2;
        spawnRate = 4;
        StartGame();
    }

    public void HardMode()
    {
        hoopSpeed = 3f;
        startHealth = 1;
        spawnRate = 2;
        StartGame();
    }
}
