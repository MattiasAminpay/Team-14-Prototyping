using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FootStep : MonoBehaviour
{

    [SerializeField] AudioClip[] audioClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    //the animation event

    private void Step()
    {
        AudioClip clip = GetRandomClip();

        audioSource.PlayOneShot(clip);
    }

    private void StepSoft()
    {
        AudioClip clip = GetRandomClip();

        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }
}