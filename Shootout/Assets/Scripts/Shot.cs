using UnityEngine;

// Shot bullet controller
public class Shot : MonoBehaviour
{
    // When bullet hit something
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other);
    }
}
