using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Delleloper.RPSTechTest.Common;

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
        [SerializeField] private TextMeshProUGUI gamesCountLabel;
        [SerializeField] private CanvasGroup buttonCanvasGroup;
        [SerializeField] private CanvasGroup GameOverCanvasGroup;

        public Sprite[] sprites;
        private PlayType playerChoice;
        private PlayType CPUChoice;
        public int PlayerScore { get; private set; }
        public int CpuScore { get; private set; }

        const string CPU_WIN = "cpuWin";
        const string HUMAN_WIN = "humanWin";
        const string TIE = "tie";

        public void Awake()
        {
            int i = 0;
            foreach (RectTransform child in buttons)
            {
                child.GetComponent<PlayButton>().Setup(sprites[i], (PlayType)i, PlayerChoice);

                if (i >= 3 && GameManager.Instance.IsClassic)
                {
                    child.gameObject.SetActive(false);
                }
                i += 1;
            }

            GameManager.Instance.onGameOver.AddListener(GameOverAnimation);
            GameManager.Instance.SetGames(5);
            UpdateValues();
        }

        public void GameOverAnimation()
        {
            StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, false, 1.0f));
            StartCoroutine(Utils.AnimateFade(GameOverCanvasGroup, true, 2.0f));
        }

        public void UpdateValues()
        {
            playerScoreLabel.text = PlayerScore.ToString();
            cpuScoreLabel.text = CpuScore.ToString();
            gamesLabel.text = GameManager.Instance.Games.ToString();
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
                PlayerScore += 1;
                triggerName = HUMAN_WIN;
            }
            else if (result == 0)
            {
                CpuScore += 1;
                triggerName = CPU_WIN;
            }
            else
            {
                triggerName = TIE;
            }

            animator.SetTrigger(triggerName);
            GameManager.Instance.DecreaseGamesCount();
            UpdateValues();
        }

        public void GoToMain()
        {
            SceneManager.LoadScene(0);
        }

        public void Reset()
        {
            PlayerScore = 0;
            CpuScore = 0;
            GameManager.Instance.SetGames(5);
            UpdateValues();
            StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, true, 0.5f));
            StartCoroutine(Utils.AnimateFade(GameOverCanvasGroup, false, 0.5f));
        }
    }
}
