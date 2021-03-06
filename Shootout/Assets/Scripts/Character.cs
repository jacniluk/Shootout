﻿using UnityEngine;

// Character in game
public class Character : MonoBehaviour
{
    [Header("Settings")]
    // Can shoot
    [SerializeField] private bool canShoot;

    [Header("Objects")]
    // Shot slot
    [SerializeField] private Transform shotSlot;
    // Aiming line
    [SerializeField] private LineRenderer aimingLine;

    [Header("References")]
    // Collider
    [SerializeField] private Collider characterCollider;
    // Animator
    [SerializeField] private Animator animator;

    [Header("Prefabs")]
    // Destroy effect
    [SerializeField] private GameObject destroyEffect;

    // Speed of rotation
    private const float RotationSpeed = 0.4f;

    // Is already dead
    private bool isDead;
    // Target which this character is aiming
    private Character aimingTarget;

    // Start
    private void Start()
    {
        UpdateAimingLine();
    }

    // Rotate character
    public void Rotate(float shift)
    {
        if (isDead) return;

        float rotation = shift * RotationSpeed;
        transform.Rotate(new Vector3(0.0f, rotation, 0.0f));

        UpdateAimingLine();
    }

    // Update aiming line
    public void UpdateAimingLine()
    {
        if (isDead || canShoot == false) return;

        aimingLine.positionCount = 1;
        aimingLine.SetPosition(0, shotSlot.position);

        Vector3 lastPoint = shotSlot.position;
        Vector3 direction = shotSlot.forward;

        RaycastHit hit;
        bool result = true;

        while (result)
        {
            result = Physics.Raycast(lastPoint, direction, out hit);
            if (result)
            {
                aimingLine.positionCount++;
                aimingLine.SetPosition(aimingLine.positionCount - 1, hit.point);

                lastPoint = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);

                aimingTarget = hit.transform.GetComponent<Character>();
                if (aimingTarget != null)
                {
                    return;
                }
            }
        }

        Vector3 fakePoint = lastPoint + 30.0f * direction;
        aimingLine.positionCount++;
        aimingLine.SetPosition(aimingLine.positionCount - 1, fakePoint);

        aimingTarget = null;
    }

    // Shoot
    public void Shoot()
    {
        if (isDead) return;

        if (canShoot)
        {
            animator.SetTrigger("Shoot");
            SoundsManager.Instance.PlayShot();

            if (aimingTarget != null)
            {
                CharactersManager.Instance.AddKilledCharacter(aimingTarget);
            }
        }
    }

    // When character is hit
    virtual public void Hit()
    {
        isDead = true;
        characterCollider.enabled = false;
        animator.SetTrigger("Die");
        aimingLine.positionCount = 0;
        Instantiate(destroyEffect, transform.position, transform.rotation);
        SoundsManager.Instance.PlayDestroy();
    }
}
