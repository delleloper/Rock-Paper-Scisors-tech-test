using Delleloper.RPSTechTest;
using Delleloper.RPSTechTest.Common;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Delleloper.RPSTechTest
{
    public class MenuManager : MonoBehaviour
    {
        public void StartGame(bool regularGame)
        {
            GameManager.Instance.SetGameType(regularGame);
            SceneManager.LoadScene(1);
            AudioManager.Instance.PlaySfx(SoundType.BUTTON);
        }
    }
}