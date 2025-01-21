
using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerScoreLabel;
        [SerializeField] private TextMeshProUGUI cpuScoreLabel;
        [SerializeField] private TextMeshProUGUI gamesLabel;
        [SerializeField] private Image cpuHand;
        [SerializeField] private Image playerHand;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform buttons;

        public Sprite[] sprites;
        private PlayType playerChoice;
        private PlayType CPUChoice;
        public int games { get; private set; } = 5;
        public int playerScore { get; private set; }
        public int cpuScore { get; private set; }
        private bool gameOver = false;

        public UnityEvent updateScore;
        public UnityEvent onGameOver;

        const string CPU_WIN = "cpuWin";
        const string HUMAN_WIN = "humanWin";
        const string TIE = "tie";

        public void Awake()
        {
            gamesLabel.text = GameManager.Instance.Games.ToString();
            int i = 0;
            foreach (RectTransform child in buttons)
            {
                child.GetComponent<PlayButton>().setup(sprites[i], (PlayType)i, PlayerChoice);

                if (i >= 4 && GameManager.Instance.IsClassic)
                {
                    child.gameObject.SetActive(false);
                }
                i += 1;
            }
        }

        public void UpdateValues()
        {
            playerScoreLabel.text = playerScore.ToString();
            cpuScoreLabel.text = cpuScore.ToString();
            gamesLabel.text = games.ToString();
        }

        public void PlayerChoice(PlayType play)
        {
            playerChoice = play;
            CPUChoice = GameManager.Instance.GetCPUChoice();
            playerHand.sprite = sprites[(int)playerChoice];
            cpuHand.sprite = sprites[(int)CPUChoice];

            int result = GameManager.Instance.GetResult(play, CPUChoice);
            string triggerName;

            if (result == 1)
            {
                playerScore += 1;
                triggerName = HUMAN_WIN;
            }
            else if (result == 0)
            {
                cpuScore += 1;
                triggerName = CPU_WIN;
            }
            else
            {
                triggerName = TIE;
            }

            animator.SetTrigger(triggerName);
            UpdateValues();
            GameManager.Instance.DecreaseGamesCount();
        }

    }
}
