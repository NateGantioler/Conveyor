using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    [Range(0.1f, 3f)] public float pitch = 1f;
    [Range(0f, 1f)] public float pitchVariation = 0f;
}

public class SFXManager : MonoBehaviour
{
    /*This is a pretty simple version of the SFX Manager, you can access it in any other script without needing a reference
    Just use "SFXManager.instance.PlaySoundEffect()"
    */

    public static SFXManager instance;

    [SerializeField] private AudioSource soundEffectSource;

    public List<SoundEffect> soundEffects;

    private float generalVolume;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(string name)
    {
        SoundEffect sfx = soundEffects.Find(s => s.name == name);
        if (sfx != null)
        {
            soundEffectSource.clip = sfx.clip;
            soundEffectSource.volume = sfx.volume * generalVolume;
            float pitchVariation = Random.Range(-sfx.pitchVariation, sfx.pitchVariation);
            soundEffectSource.pitch = sfx.pitch + pitchVariation;
            soundEffectSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound effect " + name + " not found in AudioManager.");
        }
    }

    public void MuteSFX(bool mute)
    {
        if(mute)
        {
            generalVolume = 0;
        }
        else
        {
            generalVolume = 1;
        }
    }
}
