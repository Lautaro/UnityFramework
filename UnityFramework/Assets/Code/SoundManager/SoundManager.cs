using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SoundManager : MonoBehaviour
{
    #region Static Methods
    public static void PlaySFX(string sfxName)
    {
        instance.PlaySfxByName(sfxName);
        
    }

    #endregion

    public List<string> pathsToFolders;
    static SoundManager instance ; 
    public List<Sfx> AllSfxs;
    List<AudioSource> audioPlayers;

    private void Awake()
    {
        instance = this;
    
        AllSfxs = new List<Sfx>();
        audioPlayers = new List<AudioSource>();

        // load all sound files in source folders

        List<AudioClip> allSoundFiles = new List<AudioClip>();

        foreach (string folderPath in pathsToFolders)
        {
           var filteredPath = folderPath;

            if (!filteredPath.EndsWith("/"))
            {
                filteredPath = filteredPath + "/";
            }

            if (filteredPath.StartsWith("/"))
            {
                filteredPath = filteredPath.TrimStart('/');
            }
            
            var acs= Resources.LoadAll<AudioClip>(filteredPath );
            allSoundFiles.AddRange(acs);

            print("Loaded " + allSoundFiles.Count + " sfx:s in folder: " + filteredPath);
        }
            
       


        /* 
         * foreach sound 
         * 1. If it has a divider ("-") in the filename only use the bit on the left. This will be the identifier
         * 2. If no SFX with SFXName as the identifier Create a sfx obect and give it the identifier as SfxName
         * 3. If there already is a SFX with the same SfxName then add the sound as a audioClip in the SFX         
        */

        // Load all sfx in folder 

        foreach (AudioClip audioClip in allSoundFiles)
        {
            var acName = audioClip.name;

            //1.If it has a divider("-") in the filename only use the bit on the left.
            if (acName.Contains("-"))
            {
                acName = acName.Substring(0, acName.IndexOf("-"));
            }


            var duplicatedSfx = AllSfxs.SingleOrDefault(sfx => sfx.SfxName == acName);
            if (duplicatedSfx == null)
            {
                //2.If no SFX with SFXName as the identifier Create a sfx obect and give it the identifier as SfxName
                var newSfx = new Sfx()
                {
                    SfxName = acName,
                    audioClips = new List<AudioClip>()
                    {
                        audioClip
                    }
                };

                AllSfxs.Add(newSfx);

            }
            else
            {
                //3.If there already is a SFX with the same SfxName then add the sound as a audioClip in the SFX
                duplicatedSfx.audioClips.Add(audioClip);

            }
        }

        print("Amount of Sfx: " + AllSfxs.Count);
                
    }


    void PlaySfxByName(string sfxName)
    {
        var freeAudioPlayer = GetAudioPlayer();
        var sfxToBePlayed = GetSfxByName(sfxName);
        var audioClipToBePlayed = GetRandomClipFromSfx(sfxToBePlayed); ;
        PlaySfx(freeAudioPlayer, audioClipToBePlayed);
    }

    private AudioClip GetRandomClipFromSfx(Sfx sfxToBePlayed)
    {
        AudioClip acToBePlayed;

        if (sfxToBePlayed.audioClips.Count > 1)
        {
            print("AMount of Clips: " + sfxToBePlayed.audioClips.Count);
            var randomness = UnityEngine.Random.Range(0, sfxToBePlayed.audioClips.Count);

            acToBePlayed = sfxToBePlayed.audioClips[randomness];
        }
        else
        {
            acToBePlayed = sfxToBePlayed.audioClips[0];
        }

        return acToBePlayed;
    }

    private Sfx GetSfxByName(string name)
    {

        var returnSfx = AllSfxs.FirstOrDefault(sfx => sfx.SfxName == name);

        if (returnSfx == null)
        {
            Debug.LogWarning("Sfx by name not found: " + name);
        }

        return returnSfx;

    }

    private AudioSource GetAudioPlayer()
    {
        AudioSource ap = null;
        if (audioPlayers.Any(player => !player.isPlaying))
        {
            ap = audioPlayers.First(player => !player.isPlaying);
        }
        else
        {
            ap = gameObject.AddComponent<AudioSource>();
            audioPlayers.Add(ap);
        }
        return ap;
    }

    private void PlaySfx(AudioSource audioPlayer, AudioClip acToBePlayed, Transform position = null, float? volume = null, float? pitch = null)
    {
      
        audioPlayer.clip = acToBePlayed;

        if (volume == null)
        {
            volume = 1f;
        }

        if (pitch == null)
        {
            pitch = 0f;
        }

        if (position == null)
        {
            audioPlayer.Play();
        }
        else
        {
            // This is BAD!!!
            AudioSource.PlayClipAtPoint(acToBePlayed, position.position, volume.Value);
        }
    }
}
