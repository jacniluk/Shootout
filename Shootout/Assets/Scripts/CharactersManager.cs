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

    // Awake
    private void Awake()
    {
        Instance = this;

        PrepareCharacters();
    }

    // Prepare characters list
    private void PrepareCharacters()
    {
        characters = charactersContainer.GetComponentsInChildren<Character>().ToList();
    }

    // Rotate characters during player's aiming
    public void RotateCharacters(float shift)
    {
        foreach (Character character in characters)
        {
            character.Rotate(shift);
        }
    }
}
