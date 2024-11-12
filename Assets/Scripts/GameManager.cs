using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;       // Display score on the screen
    public Text gameOverText;    // Display game over message
    public Button resetButton;   // Reference to the Reset button
    private int score = 0;
    private bool isGameOver = false;

    private void Start()
    {
        resetButton.gameObject.SetActive(false);  // Hide the Reset button at the start
        UpdateScoreUI();
    }

    // Call this to update the score
    public void AddScore(int runs)
    {
        if (!isGameOver)
        {
            score += runs;
            UpdateScoreUI();
        }
    }

    // Game over function when the player is out
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);  // Display "Out" message
        resetButton.gameObject.SetActive(true);    // Show the Reset button
        FindObjectOfType<MenuManager>().StopBallDelivery(); // Stop delivery if it's ongoing
    }

    // Call this to reset the game
    public void ResetGame()
    {
        // Reset variables
        score = 0;
        isGameOver = false;
        UpdateScoreUI();

        // Hide game over message and Reset button
        gameOverText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);

        // Optionally, reset other game components
        FindObjectOfType<MenuManager>().ShowReadyMenu();
        FindObjectOfType<MenuManager>().StopBallDelivery(); // Stop delivery if it's ongoing
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
