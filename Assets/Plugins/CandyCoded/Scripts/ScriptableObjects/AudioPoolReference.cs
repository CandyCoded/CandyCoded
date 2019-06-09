// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

        private GameObject _tempGameObject;

        public GameObject tempGameObject
        {
            get
            {

                if (_tempGameObject == null)
                {

                    _tempGameObject = new GameObject("AudioPool (Clone)");

                }

                return _tempGameObject;

            }
        }

        protected override AudioSource Create()
        {

            return tempGameObject.AddComponent<AudioSource>();

        }

        public void ReleaseAllFinishedAudioSources()
        {

            foreach (var audioSource in _activeObjects.ToList())
            {

                if (!_activeObjects[0].isPlaying)
                {

                    Release(audioSource);

                }

            }

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

        public void Play(string audioDataName)
        {

            Play(audioDataName, Retrieve());

        }

        private AudioData GetAudioDataByName(string audioDataName)
        {

            foreach (var audioData in audioDataArray)
            {

                if (audioData.name.Equals(audioDataName))
                {

                    return audioData;

                }

            }

#if UNITY_EDITOR

            throw new WarningException($"{audioDataName} not found!");

#else
            return null;

#endif

        }

        public void ResetVolumeAndPitch()
        {

            foreach (var audioData in audioDataArray)
            {

                audioData.Reset();

            }

        }

    }

#if UNITY_EDITOR

    [CustomEditor(typeof(AudioPoolReference), true)]
    public class AudioPoolReferenceEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            var script = (AudioPoolReference)target;

            if (GUILayout.Button("Reset Volume and Pitch to Default"))
            {

                script.ResetVolumeAndPitch();

            }

        }

    }

#endif

}
