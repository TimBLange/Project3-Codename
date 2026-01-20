using System;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;


public class SoundEnterInRadius : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource SoundDampened;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoundVol")
        {
        Sound.Play();
        SoundDampened.Stop();
        }
        else
        {
            return;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SoundVol")
        {
            Sound.Stop();
            SoundDampened.Play();
        }
        else
        {
            return;
        }
    }
}
