using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource dead;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource point;
    [SerializeField] private AudioSource swoosh;
    [SerializeField] private AudioSource wing;

    public void PlayClick()
    {
        click.Play();
    }
    public void PlayDead()
    {
        dead.Play();
    }
    public void PlayHit()
    {
        hit.Play();
    }
    public void PlayPoint()
    {
        point.Play();
    }
    public void PlaySwoosh()
    {
        swoosh.Play();
    }
    public void PlayWing()
    {
        wing.Play();
    }
}
