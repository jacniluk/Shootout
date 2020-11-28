using UnityEngine;

// Shot bullet controller
public class Shot : MonoBehaviour
{
    // When bullet hit something
    private void OnParticleCollision(GameObject other)
    {
        HitService(other);
    }

    // Actions after hitting something
    private void HitService(GameObject other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            character.Hit();
        }
    }
}
