using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Background Music")]
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned in BackgroundMusic script!");
        }
    }
}
