using System;
using UnityEngine;

// Player shooting controller
public class PlayerShooting : MonoBehaviour
{
    // Maximum time in seconds between press and release
    private const float MaxShootPressTime = 0.5f;
    // Minimum time in seconds between two shots
    private const float MinBreakBetweenShots = 1.0f;

    // Time when player pressed
    private DateTime pressTime;
    // Position on which player pressed
    private Vector3 pressPosition;
    // Last shot time
    private DateTime lastShotTime;

    // Update
    private void Update()
    {
        UpdateShooting();
    }

    // Update shooting
    private void UpdateShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressTime = DateTime.Now;
            pressPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if ((DateTime.Now - pressTime).TotalMilliseconds <= 1000.0f * MaxShootPressTime &&
                (DateTime.Now - lastShotTime).TotalMilliseconds >= 1000.0f * MinBreakBetweenShots &&
                Input.mousePosition == pressPosition)
            {
                lastShotTime = DateTime.Now;
                CharactersManager.Instance.CharactersShoot();
            }
        }
    }
}
