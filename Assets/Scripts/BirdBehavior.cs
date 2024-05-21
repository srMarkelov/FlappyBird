using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class BirdBehavior : MonoBehaviour
{
    [SerializeField] private float velocity; 
    [SerializeField] private Rigidbody2D rigidbody; 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxHeight;

    public Action OnCollisionGroundAndPipe;
    public Action OnTriggerPoint;
    

    private void Update()
    {
        if (transform.position.y >= maxHeight)
            return;
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,rigidbody.velocity.y * rotationSpeed);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionGroundAndPipe?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerPoint?.Invoke();
    }

    public void SetGravity(bool gravityScale)
    {
        if (gravityScale)
        {
            rigidbody.gravityScale = 1;
        }
        else
        {
            rigidbody.gravityScale = 0;
        }
    }
}
