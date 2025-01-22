using System.Linq;
using UnityEngine;

namespace Delleloper.RPSTechTest.Common
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private SoundsSO SO;
        [SerializeField] private AudioSource soundFXObject;
        public static AudioManager Instance = null;
        public bool SfxEnabled { get; private set; } = true;
        public bool MusicEnabled { get; private set; } = true;
        private AudioSource[] sfxSources = { };
        private AudioSource[] musicSources = { };

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySfx(SoundType sound, float volume = 1.0f)
        {
            SoundList soundList = Instance.SO.sounds[(int)sound];
            AudioClip clip = GetRandomClip(soundList);
            AudioSource audioSource = CreateAudioSource(soundList, volume);
            audioSource.mute = !SfxEnabled;
            audioSource.Play();
            sfxSources.Append(audioSource);

            float clipLength = clip.length;
            Destroy(audioSource.gameObject, clipLength);
        }

        public void PlayMusic(SoundType sound, float volume = 1.0f)
        {
            SoundList soundList = Instance.SO.sounds[(int)sound];
            AudioSource audioSource = CreateAudioSource(soundList, volume, true);
            audioSource.mute = !MusicEnabled;
            musicSources.Append(audioSource);
            audioSource.Play();
        }

        private AudioSource CreateAudioSource(SoundList soundList, float volume, bool loop = false)
        {
            AudioClip clip = GetRandomClip(soundList);

            AudioSource audioSource = Instantiate(soundFXObject, transform);
            audioSource.clip = clip;
            audioSource.volume = soundList.volume * volume;
            audioSource.outputAudioMixerGroup = soundList.mixer;
            audioSource.pitch = soundList.pitch;
            audioSource.loop = loop;
            return audioSource;
        }

        private AudioClip GetRandomClip(SoundList soundList)
        {
            if (soundList.sounds.Length == 1)
            {
                return soundList.sounds[0];
            }
            return soundList.sounds[UnityEngine.Random.Range(0, soundList.sounds.Length)];
        }

        public void ToggleSfx()
        {
            SfxEnabled = !SfxEnabled;
            foreach (AudioSource item in sfxSources)
            {
                if (item != null)
                {
                    item.mute = SfxEnabled;
                }
            }
        }
        public void ToggleMusic()
        {
            MusicEnabled = !MusicEnabled;
            foreach (AudioSource item in musicSources)
            {
                if (item != null)
                {
                    item.mute = MusicEnabled;
                }
            }
        }
    }


}