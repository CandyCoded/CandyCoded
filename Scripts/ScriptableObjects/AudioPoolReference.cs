// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

// ReSharper disable RequiredBaseTypesConflict

using System;
using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "AudioPoolReference", menuName = "CandyCoded/AudioPoolReference")]
    [HelpURL("https://github.com/CandyCoded/CandyCoded/blob/master/Documentation/4.%20ScriptableObject/AudioPool.md")]
    public class AudioPoolReference : PoolReference<AudioSource>
    {

        [Serializable]
        public class AudioData
        {

#pragma warning disable CS0649
            [SerializeField]
            private string _name;

            public string name => _name;

            [SerializeField]
            private AudioClip[] _clips;

            public AudioClip[] clips => _clips;
#pragma warning restore CS0649

            [RangedSlider(0, 1)]
            [SerializeField]
            private RangedFloat _volume;

            public RangedFloat volume => _volume;

            [RangedSlider(-3, 3)]
            [SerializeField]
            private RangedFloat _pitch;

            public RangedFloat pitch => _pitch;

            public void Reset()
            {

                _volume = new RangedFloat { min = 1, max = 1 };
                _pitch = new RangedFloat { min = 1, max = 1 };

            }

        }

        private GameObject _gameObject;

        public GameObject gameObject
        {
            get
            {

                if (_gameObject != null)
                {

                    return _gameObject;

                }

                _gameObject = new GameObject("AudioPool (Auto)");

                _runner = _gameObject.AddComponent<Runner>();

                return _gameObject;

            }
        }

        private Runner _runner;

#pragma warning disable CS0649
        [SerializeField]
        private AudioData[] audioDataArray;
#pragma warning restore CS0649

        private int _prevAudioDataArrayLength;

        /// <summary>
        ///     Creates a new AudioSource for use in a AudioSource pool.
        /// </summary>
        /// <returns>AudioSource</returns>
        protected override AudioSource Create()
        {

            return gameObject.AddComponent<AudioSource>();

        }

        /// <summary>
        ///     Plays an audio clip stored in the audio data array by name with a specified AudioSource component.
        /// </summary>
        /// <param name="audioDataName">String representing the audio clip to play.</param>
        /// <param name="audioSource">AudioSource component used to play an AudioClip.</param>
        /// <returns>void</returns>
        public void Play(string audioDataName, AudioSource audioSource)
        {

            var audioData = GetAudioDataByName(audioDataName);

            if (Equals(audioData, null) || audioData.clips.Length.Equals(0))
            {

                return;

            }

            audioSource.clip = audioData.clips.Random();
            audioSource.volume = audioData.volume.Random();
            audioSource.pitch = audioData.pitch.Random();
            audioSource.Play();

        }

        /// <summary>
        ///     Plays an audio clip stored in the audio data array by name with a dynamically pooled AudioSource.
        /// </summary>
        /// <param name="audioDataName">String representing the audio clip to play.</param>
        /// <returns>void</returns>
        public void Play(string audioDataName)
        {

            var audioSource = Retrieve();

            Play(audioDataName, audioSource);

            _runner.StartCoroutine(ReleaseAudioSource(audioSource));

        }

        /// <summary>
        ///     Returns an AudioData object by name.
        /// </summary>
        /// <param name="audioDataName">String representing the audio clip to play.</param>
        /// <returns>AudioData</returns>
        private AudioData GetAudioDataByName(string audioDataName)
        {

            for (var i = 0; i < audioDataArray.Length; i++)
            {

                var audioData = audioDataArray[i];

                if (audioData.name.Equals(audioDataName))
                {

                    return audioData;

                }

            }

            return null;

        }

        /// <summary>
        ///     Release AudioSource back into the object pool when the AudioClip is finished playing.
        /// </summary>
        /// <returns>IEnumerator</returns>
        private IEnumerator ReleaseAudioSource(AudioSource audioSource)
        {

            while (!Equals(audioSource.clip, null) && audioSource.isPlaying)
            {

                yield return null;

            }

            Release(audioSource);

        }

#pragma warning disable S1144

        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
        private void OnValidate()
        {

            for (var i = _prevAudioDataArrayLength; i < audioDataArray.Length; i += 1)
            {

                var audioData = audioDataArray[i];

                if (audioData.name.Equals(string.Empty) && audioData.clips.Length.Equals(0))
                {

                    audioData.Reset();

                }

            }

            _prevAudioDataArrayLength = audioDataArray.Length;

        }
#pragma warning restore S1144

    }

}
