using UnityEngine;

// Character in game
public class Character : MonoBehaviour
{
    // Speed of rotation
    private const float RotationSpeed = 0.4f;

    // Rotate character
    public void Rotate(float shift)
    {
        float rotation = shift * RotationSpeed;
        transform.Rotate(new Vector3(0.0f, rotation, 0.0f));
    }

    // When bullet hit character
    virtual public void Hit()
    {

    }
}
