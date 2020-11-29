using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Manager of all characters on scene
public class CharactersManager : MonoBehaviour
{
    [Header("Characters container")]
    // Container with all characters on scene
    [SerializeField] private Transform charactersContainer;

    // All characters on scene
    private List<Character> characters;

    // Instance
    public static CharactersManager Instance;

    // Is player dead
    private bool isPlayerDead;
    // How many enemies is still alive
    private int enemiesLeft;

    // Awake
    private void Awake()
    {
        Instance = this;

        PrepareCharacters();
    }

    // Prepare characters
    private void PrepareCharacters()
    {
        characters = charactersContainer.GetComponentsInChildren<Character>().ToList();
        enemiesLeft = characters.FindAll(x => x.GetComponent<Enemy>() != null).Count;
    }

    // Rotate characters during player's aiming
    public void RotateCharacters(float shift)
    {
        foreach (Character character in characters)
        {
            character.Rotate(shift);
        }
    }

    // Shoot by all characters
    public void CharactersShoot()
    {
        foreach (Character character in characters)
        {
            character.Shoot();
        }

        if (isPlayerDead)
        {
            GameManager.Instance.GameOver();
        }
        else if (enemiesLeft == 0)
        {
            GameManager.Instance.LevelComplete();
        }
    }

    // Player was killed
    public void SetPlayerDead()
    {
        isPlayerDead = true;
    }

    // Enemy was killed
    public void SetEnemyDead()
    {
        enemiesLeft--;
    }
}
