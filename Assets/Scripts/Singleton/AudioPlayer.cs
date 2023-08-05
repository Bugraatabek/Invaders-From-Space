using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;

    [SerializeField] int _maxAudioPlayers;
    int _playIndex = 0;
    List<AudioSource> _sources = new List<AudioSource>();
    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        for (int i = 0; i < _maxAudioPlayers; i++)
        {
            AudioSource newAudioSource = transform.gameObject.AddComponent<AudioSource>();
            newAudioSource.loop = false;
            newAudioSource.playOnAwake = false;
        }

        GetComponents<AudioSource>().ToList().ForEach(x => _sources.Add(x));
    }
    
    public void PlayAudio(AudioClip audio, float volume = 1f, bool loop = false)
    {
        AudioSource source = _sources[_playIndex];
        source.clip = audio;

        if (volume != 1f)
            source.volume = volume;

        if (!source.isPlaying)
            source.Play();

        if (_playIndex == _maxAudioPlayers)
            _playIndex = 0;
        else
            _playIndex++;
    }
}
