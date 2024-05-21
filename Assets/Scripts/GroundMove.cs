using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float width;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 _startSize;

    private void Start()
    {
        _startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    private void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);

        if (spriteRenderer.size.x > width)
        {
            spriteRenderer.size = _startSize;
        }
    }
}
