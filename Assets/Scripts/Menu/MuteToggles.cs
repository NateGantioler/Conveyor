using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteToggles : MonoBehaviour
{
    public void SoundToggle(bool value)
    {
        Debug.Log("Sound: " + value);
    }

    public void MusicToggle(bool value)
    {
        MusicManager.instance.MuteMusic(value);
    }
}
