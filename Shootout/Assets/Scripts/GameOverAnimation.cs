using System;
using System.Collections;
using UnityEngine;

// Game over panel
public class GameOverAnimation : MonoBehaviour
{
    [Header("Objects")]
    // Panel
    [SerializeField] private GameObject panel;

    [Header("References")]
    // Panel animation
    [SerializeField] private Animation panelAnimation;

    // Instance
    public static GameOverAnimation Instance;

    // Awake
    private void Awake()
    {
        Instance = this;
    }

    // Play animation
    public void Play(Action finishAction)
    {
        StartCoroutine(PlayCoroutine(finishAction));
    }

    // Play animation coroutine
    private IEnumerator PlayCoroutine(Action finishAction)
    {
        panel.SetActive(true);

        yield return new WaitWhile(() => panelAnimation.isPlaying);

        finishAction?.Invoke();
    }
}
