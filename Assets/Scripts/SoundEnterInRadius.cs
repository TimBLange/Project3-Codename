using System;
using UnityEngine;


public class SoundEnterInRadius : MonoBehaviour
{
    public AudioSource Sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoundVol")
        Sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        Sound.Stop();
    }
}
