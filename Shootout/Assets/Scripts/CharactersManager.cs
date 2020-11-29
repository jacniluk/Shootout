using System.Collections;
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

    // All characters which were killed during last shot round
    private List<Character> lastShotKilledCharacters;
    // Is player dead
    private bool isPlayerDead;
    // How many enemies is still alive
    private int enemiesLeft;

    // Awake
    private void Awake()
    {
        Instance = this;

        PrepareCharacters();

        lastShotKilledCharacters = new List<Character>();
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
        StartCoroutine(CharactersShootCoroutine());
    }

    // Shoot by all characters coroutine
    private IEnumerator CharactersShootCoroutine()
    {
        foreach (Character character in characters)
        {
            character.Shoot();
        }

        yield return new WaitForSeconds(0.2f);

        lastShotKilledCharacters.ForEach(x => x.Hit());
        lastShotKilledCharacters.Clear();

        characters.ForEach(x => x.UpdateAimingLine());

        if (isPlayerDead)
        {
            GameManager.Instance.GameOver();
        }
        else if (enemiesLeft == 0)
        {
            GameManager.Instance.LevelComplete();
        }
    }

    // Add character which was killed in current shot round
    public void AddKilledCharacter(Character killedCharacter)
    {
        lastShotKilledCharacters.Add(killedCharacter);
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
