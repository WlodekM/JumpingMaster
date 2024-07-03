using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] audios;
    public AudioClip[] audiosRandom;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = audios[Mathf.RoundToInt(Random.Range(0, audios.Length))];
            if (Random.Range(1, 3) <= 1)
            {
                audio.clip = audiosRandom[Mathf.RoundToInt(Random.Range(0, audiosRandom.Length))];
            }
            audio.Play();
        }

    }
}
