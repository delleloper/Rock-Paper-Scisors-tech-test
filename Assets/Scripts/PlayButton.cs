using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class PlayButton : MonoBehaviour
    {
        public PlayType type;
        public Sprite[] sprites;
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
            button = GetComponent<Button>();
        }

        public void Start()
        {
            if ((int)type < sprites.Length)
            {
                image.sprite = sprites[(int)type];
            }
            button.onClick.AddListener(OnPressed);
        }

        private void OnPressed()
        {
            GameManager.Instance.PlayerChoice(type);
        }
    }

}