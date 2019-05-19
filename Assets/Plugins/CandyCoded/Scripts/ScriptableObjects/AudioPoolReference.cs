// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "AudioPoolReference", menuName = "CandyCoded/AudioPoolReference")]
    public class AudioPoolReference : ScriptableObject
    {

        [Serializable]
        public class AudioData
        {

            [SerializeField]
            private string _name;

            public string name => _name;

            [SerializeField]
            private AudioClip[] _clips;

            public AudioClip[] clips => _clips;

            [RangedSlider(0, 1)]
            [SerializeField]
            private RangedFloat _volume = new RangedFloat { min = 1, max = 1 };

            public RangedFloat volume => _volume;

            [RangedSlider(-3, 3)]
            [SerializeField]
            private RangedFloat _pitch = new RangedFloat { min = 1, max = 1 };

            public RangedFloat pitch => _pitch;

        }

        private int previousAudioDataArrayLength;

#pragma warning disable CS0649
        [SerializeField]
        private AudioData[] audioDataArray;
#pragma warning restore CS0649

        public void Play(string audioDataName, AudioSource audioSource)
        {

            var audioData = GetAudioDataByName(audioDataName);

            if (audioData.clips.Length == 0)
            {

#if UNITY_EDITOR

                throw new WarningException($"{audioDataName} not found!");

#endif

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

#pragma warning disable S1144

        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
        private void OnValidate()
        {

            if (audioDataArray.Length > previousAudioDataArrayLength)
            {

                for (var i = previousAudioDataArrayLength; i < audioDataArray.Length; i += 1)
                {

                    audioDataArray[i] = new AudioData();

                }

            }

            previousAudioDataArrayLength = audioDataArray.Length;

        }

        private void Reset()
        {

            previousAudioDataArrayLength = 0;

        }

#pragma warning restore S1144

    }

}
