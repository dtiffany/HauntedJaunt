using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // with code modified from https://www.youtube.com/watch?v=DU7cgVsU2rM
    public static AudioManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource musicSource;

    // public AudioClip bgm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // musicSource.clip = bgm;
        // musicSource.Play();
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign the audioClip
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // // get length of sound effect clip
        float clipLength = audioSource.clip.length;

        // // destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSoundClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        // pick random sound
        int rand = UnityEngine.Random.Range(0, audioClip.Length);

        // spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign the audioClip
        audioSource.clip = audioClip[rand];

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // // get length of sound effect clip
        float clipLength = audioSource.clip.length;

        // // destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
