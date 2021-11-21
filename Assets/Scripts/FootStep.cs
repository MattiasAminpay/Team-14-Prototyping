using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]

public class FootStep : MonoBehaviour
{

    [SerializeField] private AudioClip[] hardSteps;
    [SerializeField] private AudioClip[] softSteps;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    //the animation event

    public void Step(AnimationEvent animationEvent)
    {
        if(animationEvent.animatorClipInfo.weight > 0.5) {
            AudioClip clip = GetRandomHardStep();
            audioSource.PlayOneShot(clip);
        }
    }

    public void StepSoft(AnimationEvent animationEvent)
    {
        if(animationEvent.animatorClipInfo.weight > 0.5) {
            AudioClip clip = GetRandomSoftStep();
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomHardStep()
    {
        int index = Random.Range(0, hardSteps.Length - 1);
        return hardSteps[index];
    }
    
    private AudioClip GetRandomSoftStep()
    {
        int index = Random.Range(0, softSteps.Length - 1);
        return softSteps[index];
    }
}