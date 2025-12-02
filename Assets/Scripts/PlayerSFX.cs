using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip Noise;
    
    public AudioSource audioSource;
    [SerializeField] public float mainVolume;

    [SerializeField] float fadeInTime = 1f;
    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] float targetVolume = 1f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Noise;
        StartCoroutine(LoopClean());
        audioSource.volume = mainVolume;
    }

    private IEnumerator LoopClean()
    {
        while (true)
        {
            audioSource.volume = 0f;
            audioSource.Play();
            
            yield return StartCoroutine(FadeVolume(0f, targetVolume, fadeInTime));
            
            float clipLength = audioSource.clip.length;
            float waitTime = clipLength - fadeOutTime;

            if (waitTime > 0f)
            {
                yield return new WaitForSeconds(waitTime);
            }
            
            yield return StartCoroutine(FadeVolume(targetVolume, 0f, fadeOutTime));
            
            audioSource.Stop();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeVolume(float start, float end, float duration)
    {
        float t = 0f;
        

        while (t < duration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, end, t / duration);
            yield return null;
        }
        audioSource.volume = end;
    }
}
