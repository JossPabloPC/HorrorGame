using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : PersistentSingleton<MusicManager>
{
    private Dictionary<string, AudioClip> m_soundFXDictionary       = null;
    private Dictionary<string, AudioClip> m_soundMusicDictionary    = null;

    private AudioSource m_backgroundMusic;
    private AudioSource m_sfxMusic;


    private float m_musicVolume = 0.5f;
    public float MusicVolume
    {
        get { return m_musicVolume; }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_musicVolume = value;
        }
    }
    public float MusicVolumeSave
    {
        get { return m_SFXVolume; }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_sfxMusic.volume = m_musicVolume;
            PlayerPrefs.SetFloat(AppPlayerPrefKeys.MUSIC_VOLUME, value);
            m_musicVolume = value;
        }
    }


    private float m_SFXVolume = 0.5f;
    public float SFXVolume
    {
        get { return m_SFXVolume; }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_SFXVolume = value;
        }
    }
    public float SFXVolumeSave
    {
        get { return m_SFXVolume; }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_sfxMusic.volume = m_SFXVolume;
            PlayerPrefs.SetFloat(AppPlayerPrefKeys.SFX_VOLUME, value);
            m_SFXVolume = value;
        }
    }


    public override void Awake()
    {
        base.Awake();

        m_backgroundMusic = CreateAudioSource("Music", true);
        m_sfxMusic = CreateAudioSource("SFX", false);

        MusicVolume = PlayerPrefs.GetFloat(AppPlayerPrefKeys.MUSIC_VOLUME, 0.5f);
        SFXVolume   = PlayerPrefs.GetFloat(AppPlayerPrefKeys.SFX_VOLUME, 0.5f);

        m_soundFXDictionary     = new Dictionary<string, AudioClip>();
        m_soundMusicDictionary  = new Dictionary<string, AudioClip>();
        

        AudioClip[] audio_Vector = Resources.LoadAll<AudioClip>(AppPaths.PATH_RESOURCE_SFX);
        for (int i = 0; i < audio_Vector.Length; i++)
        {//Loads clips to the SFX dictionary
            m_soundFXDictionary.Add(audio_Vector[i].name, audio_Vector[i]);
        }

        audio_Vector = Resources.LoadAll<AudioClip>(AppPaths.PATH_RESOURCE_MUSIC);
        for (int i = 0; i < audio_Vector.Length; i++)
        {//Loads clips to the Music dictionary
            m_soundMusicDictionary.Add(audio_Vector[i].name, audio_Vector[i]);
        }

    }

    /// <summary>
    /// Creates an audio source
    /// </summary>
    /// <param name="of the audio source"="name"></param>
    /// <param name="isLoop"></param>
    /// <returns></returns>
    public AudioSource CreateAudioSource (string name, bool isLoop)
    {
        GameObject temp_audio_host = new GameObject(name);
        AudioSource audioSource = temp_audio_host.AddComponent<AudioSource>() as AudioSource;
        audioSource.playOnAwake = false;
        audioSource.loop = isLoop;
        audioSource.spatialBlend = 0.0f;
        temp_audio_host.transform.SetParent(this.transform);
        return audioSource;
    }

    /// <summary>
    /// Access the music dictionary and play an specific audio
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayMusic (string audioName)
    {
        if (m_soundMusicDictionary.ContainsKey(audioName))
        {
            m_backgroundMusic.clip = m_soundMusicDictionary[audioName];
            m_backgroundMusic.volume = m_musicVolume;
            m_backgroundMusic.Play();
        }
        else
            Debug.LogError("No audio called " + audioName + " in " + AppPaths.PATH_RESOURCE_MUSIC);
    }

    /// <summary>
    /// Access the SFX dictionary and play an specific audio
    /// </summary>
    /// <param name="audioName"></param>
    public void PlaySound(string audioName)
    {
        if (m_soundFXDictionary.ContainsKey(audioName))
        {
            m_sfxMusic.clip = m_soundFXDictionary[audioName];
            m_sfxMusic.volume = m_musicVolume;
            m_sfxMusic.Play();
        }
        else
            Debug.LogError("No audio called " + audioName + " in " + AppPaths.PATH_RESOURCE_SFX);
    }

    public void StopMusic()
    {
        if(m_backgroundMusic != null)
            m_backgroundMusic.Stop();
    }

    public void PauseMusic()
    {
        if (m_backgroundMusic != null)
            m_backgroundMusic.Pause();
    }
}
