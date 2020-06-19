using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource audioFX;
    public AudioClip[] audios;
    public static AudioManager instance = null;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        audioFX = this.GetComponent<AudioSource>();
    }

    public void trocarCarta(){
        audioFX.PlayOneShot(audios[0]);
    }

    public void tocarRespostaCorreta(){
        audioFX.PlayOneShot(audios[1]);
    }

    public void tocarRespostaErrada(){
        audioFX.PlayOneShot(audios[2]);
    }
}