using Delleloper.RPSTechTest.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Delleloper.RPSTechTest
{
    public class MenuManager : MonoBehaviour
    {
        public void Start()
        {
            AudioManager.Instance.PlayMusic(SoundType.MUSIC);
        }

        public void StartGame(bool regularGame)
        {
            GameManager.Instance.SetGameType(regularGame);
            SceneManager.LoadScene(1);
            AudioManager.Instance.PlaySfx(SoundType.BUTTON);
        }
    }
}