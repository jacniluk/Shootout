using UnityEngine;

// Player aiming controller
public class PlayerAiming : MonoBehaviour
{
    // Speed of rotation
    private const float RotationSpeed = 0.4f;

    // Is player currently aiming
    private bool isAiming;
    // Last mouse position in x axis during aiming
    private float lastXposition;

    // Update
    private void Update()
    {
        UpdateAiming();
    }

    // Update aiming
    private void UpdateAiming()
    {
        UpdateIsAiming();

        if (isAiming)
        {
            UpdateRotation();
        }
    }

    // Update state of aiming
    private void UpdateIsAiming()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
            lastXposition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAiming = false;
        }
    }

    // Update player rotation during aiming
    private void UpdateRotation()
    {
        float shift = Input.mousePosition.x - lastXposition;
        lastXposition = Input.mousePosition.x;
        RotatePlayer(shift);
    }

    // Rotate character during aiminig
    private void RotatePlayer(float shift)
    {
        float rotation = shift * RotationSpeed;
        transform.Rotate(new Vector3(0.0f, rotation, 0.0f));
    }
}
