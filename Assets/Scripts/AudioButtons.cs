using Delleloper.RPSTechTest.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class AudioButtons : MonoBehaviour
    {
        [SerializeField] private Button musicButton;
        [SerializeField] private Button sfxButton;
        [SerializeField] private Image musicSprite;
        [SerializeField] private Image sfxSprite;
        [SerializeField] private Sprite sfxSpriteOn;
        [SerializeField] private Sprite sfxSpriteOff;
        [SerializeField] private Sprite MusicSpriteOn;
        [SerializeField] private Sprite MusicSpriteOff;

        public void Awake()
        {
            musicButton.onClick.AddListener(MusicClick);
            sfxButton.onClick.AddListener(SfxClick);
        }

        private void MusicClick()
        {
            AudioManager.Instance.ToggleMusic();
            musicSprite.sprite = AudioManager.Instance.MusicEnabled ? MusicSpriteOn : MusicSpriteOff;
            AudioManager.Instance.PlaySfx(SoundType.BUTTON);
        }

        private void SfxClick()
        {
            AudioManager.Instance.ToggleSfx();
            sfxSprite.sprite = AudioManager.Instance.SfxEnabled ? sfxSpriteOn : sfxSpriteOff;
            AudioManager.Instance.PlaySfx(SoundType.BUTTON);
        }
    }
}