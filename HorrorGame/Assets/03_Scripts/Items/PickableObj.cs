using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public abstract class PickableObj : MonoBehaviour
{
    public AudioClip    SFX;
    public GameObject   VFX;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource> ();
        _audioSource.clip = SFX;
    }

    public virtual void OnTriggerWithPlayer(PlayerStats playerStats)
    {
        PlayAudio();
        SpawnVFX();
    }

    protected virtual void PlayAudio()
    {
        if(SFX != null)
        {
            _audioSource.Play();
        }
    }

    protected virtual void SpawnVFX()
    {
    }

}
