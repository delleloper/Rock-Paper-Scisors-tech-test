using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class PlayButton : MonoBehaviour
    {
        public PlayType type;
        [SerializeField] private Image image;
        private Button button;

        public void Awake()
        {
            if (GameManager.Instance.IsClassic)
            {
                if (type == PlayType.SPOCK || type == PlayType.LIZARD)
                {
                    gameObject.SetActive(false);
                    return;
                }
            }
        }

        public void setup(Sprite sprite, PlayType playType, System.Action<PlayType> playerChoice)
        {
            image.sprite = sprite;
            type = playType;
            button = GetComponent<Button>();
            button.onClick.AddListener(() => { playerChoice.Invoke(type); });
        }
    }

}