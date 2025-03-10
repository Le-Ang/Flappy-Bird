using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip audioFlap;
    [SerializeField] private AudioClip audioGameOver;
    [SerializeField] private AudioClip audioReady;

    private AudioSource mainAudio;
    // Start is called before the first frame update
    void Start()
    {
        mainAudio = gameObject.GetComponent<AudioSource>();
        mainAudio.clip = audioReady;
        mainAudio.Play();
    }

    // Update is called once per frame
    public void AudioGameOver()
    {
        mainAudio.clip = audioGameOver;
        mainAudio.Play();
    }
    public void AudioFlap()
    {
        mainAudio.clip=audioFlap;
        mainAudio.Play();
    }
}
