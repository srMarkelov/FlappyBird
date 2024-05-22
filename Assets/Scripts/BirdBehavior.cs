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
    [SerializeField] private AudioHandler audioHandler;

    public Action OnCollisionGroundAndPipe;
    public Action OnTriggerPoint;

    private bool deadBird; 
    

    private void Update()
    {
        FlapWing();
    }
    
    private void FixedUpdate()
    {
        AdjustRotation();
    }

    private void FlapWing()
    {
        if (transform.position.y >= maxHeight)
            return;

        if (deadBird)
            return;
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            audioHandler.PlayWing();
            rigidbody.velocity = Vector2.up * velocity;
        }
    }

    private void AdjustRotation()
    {
        transform.rotation = Quaternion.Euler(0,0,rigidbody.velocity.y * rotationSpeed);
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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionGroundAndPipe?.Invoke();
        deadBird = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        audioHandler.PlayPoint();
        OnTriggerPoint?.Invoke();
    }
}
