using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace SoundManager
{

    public class SoundManager : MonoBehaviour
    {
        #region Static Methods
        public static void PlaySFX(GameObject source, string sfxName)
        {
            instance.PlaySfxByName(sfxName, source);
        }

        public static void PlaySFX(GameObject source, string sfxName, float pitch)
        {
            instance.PlaySfxByName(sfxName, source, pitch);
        }

        #endregion

        public List<string> pathsToFolders;
        static SoundManager instance;
        public List<Sfx> AllSfxs;
        //List<AudioSource> audioPlayers;

        #region Setup

        private void Awake()
        {
            instance = this;

            AllSfxs = new List<Sfx>();

            List<AudioClip> allSoundFiles = new List<AudioClip>();

            // FOREACH FOLDER PATHS LOAD AUDIOCLIPS
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
                var acs = Resources.LoadAll<AudioClip>(filteredPath);

                allSoundFiles.AddRange(acs);

            }


            // MAKE AUDIOCLIPS OF EVERY SOUND
            foreach (AudioClip audioClip in allSoundFiles)
            {
                var acName = audioClip.name;
                print(audioClip.name);

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
        }

        #endregion

        #region Play Sfxs

        void PlaySfxByName(string sfxName, GameObject source)
        {
            var freeAudioPlayer = GetAudioPlayer(source);
            var sfxToBePlayed = GetSfxByName(sfxName);
            var audioClipToBePlayed = GetRandomClipFromSfx(sfxToBePlayed); ;
            PlaySfx(freeAudioPlayer, audioClipToBePlayed);
        }

        void PlaySfxByName(string sfxName, GameObject source, float pitch)
        {
            var freeAudioPlayer = GetAudioPlayer(source);
            var sfxToBePlayed = GetSfxByName(sfxName);
            var audioClipToBePlayed = GetRandomClipFromSfx(sfxToBePlayed); ;
            PlaySfx(freeAudioPlayer, audioClipToBePlayed, null, null, pitch);
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
                pitch = 1f;
            }

            //audioPlayer.volume = volume ?? 0;
            audioPlayer.pitch = pitch ?? 1;
            print("P : " + audioPlayer.pitch);
            print(audioPlayer.volume);

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

        #endregion

        #region Internal Helpers

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

        private AudioSource GetAudioPlayer(GameObject source)
        {
            var allAudioSources = source.GetComponents<AudioSource>();

            AudioSource ap = null;
            if (allAudioSources.Any(player => !player.isPlaying))
            {
                ap = allAudioSources.First(player => !player.isPlaying);
            }
            else
            {
                ap = source.AddComponent<AudioSource>();
            }
            return ap;

        }

        #endregion
    }


    public static class SoundManagerExtensions
    {
        public static void PlaySFX(this GameObject source, string sfxName)
        {
            SoundManager.PlaySFX(source, sfxName);
        }

        public static void PlaySFX(this GameObject source, string sfxName, float pitch)
        {
            SoundManager.PlaySFX(source, sfxName, pitch);
        }
    }
}