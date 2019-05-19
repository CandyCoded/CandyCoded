// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "AudioPoolReference", menuName = "CandyCoded/AudioPoolReference")]
    public class AudioPoolReference : ScriptableObject
    {

        [Serializable]
        public struct AudioData
        {

            public string name;

            public AudioClip[] clips;

            [RangedSlider(0, 1)]
            public RangedFloat volume;

            [RangedSlider(-3, 3)]
            public RangedFloat pitch;

        }

#pragma warning disable CS0649
        [SerializeField]
        private AudioData[] audioDataArray;
#pragma warning restore CS0649

        public void Play(string audioDataName, AudioSource audioSource)
        {

            var audioData = GetAudioDataByName(audioDataName);

            if (audioData.clips.Length == 0)
            {
                return;
            }

            audioSource.clip = audioData.clips.Random();
            audioSource.volume = audioData.volume.Random();
            audioSource.pitch = audioData.pitch.Random();
            audioSource.Play();

        }

        private AudioData GetAudioDataByName(string audioDataName)
        {

            return audioDataArray.FirstOrDefault(audioData => audioData.name.Equals(audioDataName));

        }

    }

}
