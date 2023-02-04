using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip music;

    [SerializeField] AudioClip click;

    public void LaunchMusic()
    {
        audioSource.PlayOneShot(music);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }
}
