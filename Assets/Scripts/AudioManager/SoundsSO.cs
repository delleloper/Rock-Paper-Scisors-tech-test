using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Delleloper.RPSTechTest.Common
{
    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        [Range(0, 1)] public float volume;
        [Range(-3, 3)] public float pitch;
        public AudioMixerGroup mixer;
        public AudioClip[] sounds;
    }
    [CreateAssetMenu(fileName = "Sounds SO")]

    public class SoundsSO : ScriptableObject
    {
        public SoundList[] sounds;
    }
}