using UnityEngine;

// Character in game
public class Character : MonoBehaviour
{
    [Header("Settings")]
    // Can shoot
    [SerializeField] private bool canShoot;

    [Header("Objects")]
    // Bullet fire slot
    [SerializeField] private Transform shotSlot;

    [Header("Prefabs")]
    // Bullet shot
    [SerializeField] private GameObject shotPrefab;

    // Speed of rotation
    private const float RotationSpeed = 0.4f;

    // Rotate character
    public void Rotate(float shift)
    {
        float rotation = shift * RotationSpeed;
        transform.Rotate(new Vector3(0.0f, rotation, 0.0f));
    }

    // Shoot
    public void Shoot()
    {
        if (canShoot)
        {
            GameObject shot = Instantiate(shotPrefab, shotSlot.position, transform.rotation);
        }
    }

    // When bullet hit character
    virtual public void Hit()
    {

    }
}
