using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx
{
    public List<AudioClip> audioClips;
    private string sfxName;
    private float? pitch;
    private float? volume;
    private Transform position;

    public string SfxName
    {
        get
        {
            return sfxName;
        }

        set
        {
            sfxName = value;
        }
    }

    public float? Pitch
    {
        get
        {
            return pitch;
        }

        set
        {
            pitch = value;
        }
    }

    public float? Volume
    {
        get
        {
            return volume;
        }

        set
        {
            volume = value;
        }
    }

    public Transform Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public Sfx()
    {
        audioClips = new List<AudioClip>();
        
    }


}
