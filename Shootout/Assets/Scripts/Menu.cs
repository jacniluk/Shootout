using UnityEngine;
using UnityEngine.SceneManagement;

// Main menu in game
public class Menu : MonoBehaviour
{
    // Play game from first level
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    // Escape game
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
