// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "AudioPoolReference", menuName = "CandyCoded/AudioPoolReference")]
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

        protected override AudioSource Create()
        {

            return gameObject.AddComponent<AudioSource>();

        }

#pragma warning disable CS0649
        [SerializeField]
        private AudioData[] audioDataArray;
#pragma warning restore CS0649

        private int prevAudioDataArrayLength;

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

        public void Play(string audioDataName)
        {

            var audioSource = Retrieve();

            Play(audioDataName, audioSource);

            _runner.StartCoroutine(ReleaseAudioSource(audioSource));

        }

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

        private IEnumerator ReleaseAudioSource(AudioSource audioSource)
        {

            while (!Equals(audioSource.clip, null) && audioSource.isPlaying)
            {

                yield return null;

            }

            Release(audioSource);

        }

        public void OnValidate()
        {

            for (var i = prevAudioDataArrayLength; i < audioDataArray.Length; i += 1)
            {

                var audioData = audioDataArray[i];

                if (audioData.name.Equals(string.Empty) && audioData.clips.Length.Equals(0))
                {

                    audioData.Reset();

                }

            }

            prevAudioDataArrayLength = audioDataArray.Length;

        }

    }

}
