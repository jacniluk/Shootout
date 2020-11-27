using System;
using UnityEngine;

// Player shooting controller
public class PlayerShooting : MonoBehaviour
{
    [Header("Objects")]
    // Bullet fire slot
    [SerializeField] private Transform shotSlot;

    [Header("Prefabs")]
    // Bullet shot
    [SerializeField] private GameObject shotPrefab;

    // Maximum time in seconds between press and release
    private const float MaxShootPressTime = 0.5f;

    // Time when player pressed
    private DateTime pressTime;
    // Position on which player pressed
    private Vector3 pressPosition;

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
            if ((DateTime.Now - pressTime).Milliseconds <= 1000.0f * MaxShootPressTime && Input.mousePosition == pressPosition)
            {
                Shoot();
            }
        }
    }

    // Shoot
    private void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab, shotSlot.position, transform.rotation);
    }
}
