using UnityEngine;

// Sounds manager
public class SoundsManager : MonoBehaviour
{
    // Instance
    public static SoundsManager Instance;

    [Header("Sounds")]
    // Shot sound
    [SerializeField] private AudioSource shot;
    // Character destroy sound
    [SerializeField] private AudioSource destroy;

    // Awake
    private void Awake()
    {
        Instance = this;
    }

    // Play shot sound
    public void PlayShot()
    {
        shot.Play();
    }

    // Play destroy sound
    public void PlayDestroy()
    {
        destroy.Play();
    }
}
