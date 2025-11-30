using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public struct SoundParameters
{
    [Range(0, 1)]
    public float Volume;
    [Range(-3, 3)]
    public float Pitch;
    public bool Loop;
}
[System.Serializable()]
public class Sound
{
    [SerializeField] string name;
    public string Name {get {return name;}}
    [SerializeField] AudioClip clip;
    public AudioClip Clip {get {return clip;}}
    [SerializeField] SoundParameters parameters;
    public SoundParameters Parameters {get {return parameters;}}
    [HideInInspector]
    public AudioSource Source;
    public void Play()
    {
        Source.clip = Clip;
        Source.volume = Parameters.Volume;
        Source.pitch = Parameters.Pitch;
        Source.loop = Parameters.Loop;
        Source.Play();
    }
    public void Stop()
    {
        Source.Stop();
    }
}
public class QuizAudioManager : MonoBehaviour
{
    public static QuizAudioManager Instance;
    [SerializeField] Sound[] sounds;
    [SerializeField] AudioSource sourcePrefabs;
    [SerializeField] string startUpTrack;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitSounds();
    }
    void Start()
    {
        if (string.IsNullOrEmpty(startUpTrack) != true)
        {
            PlaySound(startUpTrack);
        }
    }
    void InitSounds()
    {
        foreach (var sound in sounds)
        {
            AudioSource source = (AudioSource)Instantiate(sourcePrefabs, gameObject.transform);
            source.name = sound.Name;
            sound.Source = source;
        }
    }
    public void PlaySound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("Warning! Sound doesn't work, I give up");
        }
    }
    public void StopSound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Stop();
        }
        else
        {
            Debug.LogWarning("Warning! Sound doesn't stop, I give up");
        }
    }
    Sound GetSound (string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.Name == name)
            {
                return sound;
            }
        }
        return null;
    }
}
