using UnityEngine;

// Resolution manager for scaling
public class ResolutionManager : MonoBehaviour
{
    // Start
    private void Start()
    {
        SetCameraFieldOfView();
    }

    // Set camera FOV depending on device screen width
    private void SetCameraFieldOfView()
    {
        float normalAspectRatio = 1920.0f / 1080.0f;
        float aspectRatio = (float)Screen.height / Screen.width;
        float factor = aspectRatio / normalAspectRatio;
        Camera.main.fieldOfView *= factor;
    }
}
