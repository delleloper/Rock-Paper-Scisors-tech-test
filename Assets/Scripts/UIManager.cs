
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerScore;
        [SerializeField] private TextMeshProUGUI cpuScore;
        [SerializeField] private TextMeshProUGUI games;
        [SerializeField] private Image cpuHand;
        [SerializeField] private Image playerHand;

        public void Awake()
        {
            GameManager.Instance.updateScore.AddListener(UpdateValues);
            games.text = GameManager.Instance.Games.ToString();

        }
        public void UpdateValues()
        {
            playerScore.text = GameManager.Instance.PlayerScore.ToString();
            cpuScore.text = GameManager.Instance.CpuScore.ToString();
            games.text = GameManager.Instance.Games.ToString();
        }
    }
}
