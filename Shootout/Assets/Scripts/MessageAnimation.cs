using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Game over panel
public class MessageAnimation : MonoBehaviour
{
    [Header("Objects")]
    // Panel
    [SerializeField] private GameObject panel;
    // Message text
    [SerializeField] private Text message;

    [Header("References")]
    // Panel animation
    [SerializeField] private Animation panelAnimation;

    // Instance
    public static MessageAnimation Instance;

    // Awake
    private void Awake()
    {
        Instance = this;
    }

    // Show message animation
    public void ShowMessage(string messageText, Action finishAction)
    {
        message.text = messageText;
        StartCoroutine(ShowMessageCoroutine(finishAction));
    }

    // Message animation coroutine
    private IEnumerator ShowMessageCoroutine(Action finishAction)
    {
        panel.SetActive(true);

        yield return new WaitWhile(() => panelAnimation.isPlaying);

        finishAction?.Invoke();
    }
}
