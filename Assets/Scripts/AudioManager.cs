using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip dynamite;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip crushed;
    [SerializeField] AudioClip destroyDirt;
    [SerializeField] AudioClip destroyGravel;
    [SerializeField] AudioClip destroyStone;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }

    public void PlayDynamiteSound(float delay)
    {
        audioSource.PlayOneShot(dynamite);

        DOVirtual.DelayedCall(delay, () => audioSource.PlayOneShot(explosion));
    }

    public void PlayCrushedSound()
    {
        audioSource.PlayOneShot(crushed);
    }

    public void PlayDestroyDirtSound()
    {
        audioSource.PlayOneShot(destroyDirt);
    }
    public void PlayDestroyGravelSound()
    {
        audioSource.PlayOneShot(destroyGravel);
    }
    public void PlayDestroyStoneSound()
    {
        audioSource.PlayOneShot(destroyStone);
    }
}
