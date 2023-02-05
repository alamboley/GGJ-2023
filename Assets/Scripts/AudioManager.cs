using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip dynamite;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip crushed;
    [SerializeField] AudioClip coinBlue;
    [SerializeField] AudioClip coinRed;
    [SerializeField] AudioClip coinYellow;
    [SerializeField] AudioClip destroyDirt;
    [SerializeField] AudioClip destroyGravel;
    [SerializeField] AudioClip destroyStone;
    [SerializeField] AudioClip fallenGravel;
    [SerializeField] AudioClip fallenObsidienne;
    [SerializeField] AudioClip fallenStone;

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

    public void PlayCoinBlueSound()
    {
        audioSource.PlayOneShot(coinBlue);
    }
    public void PlayCoinRedSound()
    {
        audioSource.PlayOneShot(coinRed);
    }
    public void PlayCoinYellowSound()
    {
        audioSource.PlayOneShot(coinYellow);
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

    public void PlayFallenGravelSound()
    {
        audioSource.PlayOneShot(fallenGravel);
    }
    public void PlayFallenObsidienneSound()
    {
        audioSource.PlayOneShot(fallenObsidienne);
    }
    public void PlayFallenStoneSound()
    {
        audioSource.PlayOneShot(fallenStone);
    }
}
