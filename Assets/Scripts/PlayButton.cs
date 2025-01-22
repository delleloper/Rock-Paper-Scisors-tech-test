using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class PlayButton : MonoBehaviour
    {
        public PlayType type;
        [SerializeField] private Image image;
        private Button button;

        public void Setup(Sprite sprite, PlayType playType, System.Action<PlayType> playerChoice)
        {
            image.sprite = sprite;
            type = playType;
            button = GetComponent<Button>();
            button.onClick.AddListener(() => { playerChoice.Invoke(type); });
        }
    }
}