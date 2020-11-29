using UnityEngine;
using UnityEngine.SceneManagement;

// Game manager
public class GameManager : MonoBehaviour
{
    // Instance
    public static GameManager Instance;

    // Is round ending
    private bool isRoundEnding;

    // Awake
    public void Awake()
    {
        Instance = this;
    }

    // Level complete
    public void LevelComplete()
    {
        isRoundEnding = true;

        if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
        {
            MessageAnimation.Instance.ShowMessage("Level complete!", LevelUp);
        }
        else
        {
            MessageAnimation.Instance.ShowMessage("You win!", WinGame);
        }
    }

    // Go to next level
    private void LevelUp()
    {
        SceneManager.LoadScene("Level" + (SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Player wins whole game
    private void WinGame()
    {
        SceneManager.LoadScene("Menu");
    }

    // Game over
    public void GameOver()
    {
        isRoundEnding = true;

        MessageAnimation.Instance.ShowMessage("Fail!", RestartLevel);
    }

    // Restart current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Check if round is ending
    public bool IsRoundEnding()
    {
        return isRoundEnding;
    }
}
