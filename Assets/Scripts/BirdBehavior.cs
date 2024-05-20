using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBehavior : MonoBehaviour
{
    [SerializeField] private float Velocity;
    [SerializeField] private Rigidbody2D Rigidbody;
    [SerializeField] private float RotationSpeed;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Rigidbody.velocity = Vector2.up * Velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,Rigidbody.velocity.y * RotationSpeed);
    }
}
