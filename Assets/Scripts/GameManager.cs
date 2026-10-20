using UnityEngine;
using UnityEngine.SceneManagement;  // needed to restart the scene
using TMPro;                        // needed for TextMeshPro text

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   // other scripts use GameManager.instance

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;      // leave EMPTY until Part 10

    public int lives = 3;
    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;              // make sure the game is running
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // hide the Game Over screen
        }
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (isGameOver) return;
        lives--;
        UpdateUI();
        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER! Final score: " + score);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // show the Game Over screen
        }
        Time.timeScale = 0f;               // freeze the game
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

