using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	private int currentindex = 0;

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Start(){
		Play("Theme");
	}

    private void FixedUpdate()
    {
        if (!sounds[currentindex].source.isPlaying)
		{
			currentindex = (currentindex + 1) % sounds.Length;

            sounds[currentindex].source.volume = sounds[currentindex].volume * (1f + UnityEngine.Random.Range(-sounds[currentindex].volumeVariance / 2f, sounds[currentindex].volumeVariance / 2f));
            sounds[currentindex].source.pitch = sounds[currentindex].pitch * (1f + UnityEngine.Random.Range(-sounds[currentindex].pitchVariance / 2f, sounds[currentindex].pitchVariance / 2f));

            sounds[currentindex].source.Play();
        }
    }

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

}
