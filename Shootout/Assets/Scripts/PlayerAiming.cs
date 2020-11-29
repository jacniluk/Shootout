using UnityEngine;

// Player aiming controller
public class PlayerAiming : MonoBehaviour
{
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
        if (GameManager.Instance.IsRoundEnding()) return;

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
        CharactersManager.Instance.RotateCharacters(shift);
    }
}
