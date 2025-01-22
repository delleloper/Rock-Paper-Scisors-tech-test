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
        [SerializeField] private TextMeshProUGUI winnerLabel;
        [SerializeField] private Button ResetButton;

        public Sprite[] sprites;
        private PlayType playerChoice;
        private PlayType CPUChoice;
        public int PlayerScore { get; private set; }
        public int CpuScore { get; private set; }

        const string CPU_WIN_TRIGGER = "cpuWin";
        const string HUMAN_WIN_TRIGGER = "humanWin";
        const string TIE_TRIGGER = "tie";
        const string HUMAN_WIN = "Human wins!";
        const string CPU_WIN = "CPU wins!";
        const string TIE = "Tied!";
        private bool clickEnabled = true;

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

            // GameManager.Instance.onGameOver.AddListener(GameOverAnimation);
            GameManager.Instance.SetGames(5);
            UpdateValues();
            ResetButton.gameObject.SetActive(false);

        }

        public void AnimationEnded()
        {
            UpdateValues();
            if (GameManager.Instance.gameOver)
            {
                GameOverAnimation();
            }
            else
            {
                StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, true, 0.5f));
            }
            clickEnabled = true;
            ResetButton.gameObject.SetActive(true);

        }
        public void GameOverAnimation()
        {
            if (PlayerScore > CpuScore)
            {
                winnerLabel.text = HUMAN_WIN;
                AudioManager.Instance.PlaySfx(SoundType.GAMEOVER_WIN);
            }
            else if (CpuScore > PlayerScore)
            {
                winnerLabel.text = CPU_WIN;
                AudioManager.Instance.PlaySfx(SoundType.GAMEOVER_LOSE);

            }
            else
            {
                winnerLabel.text = TIE;
            }
            StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, false, 1.0f));
            StartCoroutine(Utils.AnimateFade(GameOverCanvasGroup, true, 1.0f));
        }

        public void UpdateValues()
        {
            playerScoreLabel.text = PlayerScore.ToString();
            cpuScoreLabel.text = CpuScore.ToString();
            gamesLabel.text = GameManager.Instance.Games.ToString();
        }

        public void PlayerChoice(PlayType play)
        {
            if (!clickEnabled)
            {
                return;
            }

            clickEnabled = false;
            playerChoice = play;
            CPUChoice = GameManager.Instance.GetCPUChoice();
            playerHand.sprite = sprites[(int)playerChoice];
            cpuHand.sprite = sprites[(int)CPUChoice];

            int result = GameManager.Instance.GetResult(play, CPUChoice);
            string triggerName;

            if (result == 1)
            {
                PlayerScore += 1;
                triggerName = HUMAN_WIN_TRIGGER;
            }
            else if (result == 0)
            {
                CpuScore += 1;
                triggerName = CPU_WIN_TRIGGER;
            }
            else
            {
                triggerName = TIE_TRIGGER;
            }

            animator.SetTrigger(triggerName);
            GameManager.Instance.DecreaseGamesCount();
            StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, false, 0.5f));
        }

        public void GoToMain()
        {
            SceneManager.LoadScene(0);
        }

        public void Reset()
        {
            PlayerScore = 0;
            ResetButton.gameObject.SetActive(false);
            CpuScore = 0;
            GameManager.Instance.SetGames(5);
            GameManager.Instance.gameOver = false;
            UpdateValues();
            StartCoroutine(Utils.AnimateFade(buttonCanvasGroup, true, 0.5f));
            StartCoroutine(Utils.AnimateFade(GameOverCanvasGroup, false, 0.5f));
        }
    }
}
