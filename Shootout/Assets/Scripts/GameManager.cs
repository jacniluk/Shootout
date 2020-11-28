using UnityEngine;
using UnityEngine.SceneManagement;

// Game manager
public class GameManager : MonoBehaviour
{
    // Instance
    public static GameManager Instance;

    // Awake
    public void Awake()
    {
        Instance = this;
    }

    // Game over
    public void GameOver()
    {
        GameOverAnimation.Instance.Play(RestartLevel);
    }

    // Restart current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
