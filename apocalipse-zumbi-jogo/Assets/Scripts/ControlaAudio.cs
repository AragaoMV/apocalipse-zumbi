using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
        private AudioSource meuAudioSource;
        public static AudioSource instacia;

        void Awake()             
        {
            meuAudioSource = GetComponent<AudioSource>();
            instacia = meuAudioSource;
        }
}
