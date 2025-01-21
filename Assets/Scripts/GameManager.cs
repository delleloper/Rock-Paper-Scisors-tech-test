using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Delleloper.RPSTechTest
{
    public class GameManager : MonoBehaviour
    {
        public int PlayerScore { get; private set; } = 0;
        public int CpuScore { get; private set; } = 0;
        public bool IsClassic { get; private set; } = true;
        public static GameManager Instance;
        private PlayType playerChoice;
        private PlayType CPUChoice;
        public int Games { get; private set; } = 5;
        private bool gameOver = false;
        public UnityEvent updateScore;
        public UnityEvent onGameOver;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            Reset();
        }

        public void Reset()
        {
            PlayerScore = 0;
            CpuScore = 0;
            gameOver = false;
            Games = 5;
        }

        public void PlayerChoice(PlayType play)
        {
            playerChoice = play;
            CPUChoice = GetCPUChoice();
            Games -= 1;
            int result = GetResult();

            if (result == 1)
            {
                PlayerScore += 1;
            }
            else if (result == 0)
            {
                CpuScore += 1;
            }

            updateScore.Invoke();
            if (Games == 0)
            {
                gameOver = true;
                onGameOver.Invoke();
            }
        }

        public PlayType GetCPUChoice()
        {
            int choices;
            PlayType result;
            if (IsClassic)
            {
                choices = 2;
            }
            else
            {
                choices = 4;
            }

            result = (PlayType)UnityEngine.Random.Range(0, choices);
            return result;
        }

        // if player wins this function returns 1
        // if player loses returns 0
        // if tie returns -1
        public int GetResult()
        {
            Debug.Log($"HUMAN PLAYS: {Enum.GetName(typeof(PlayType), playerChoice)} ");
            Debug.Log($"CPU PLAYS: {Enum.GetName(typeof(PlayType), CPUChoice)} ");
            if (playerChoice == CPUChoice)
            {
                Debug.Log("TIE");
                return -1;
            }
            var loseConditions = new Dictionary<PlayType, List<PlayType>>()
            {
                { PlayType.ROCK, new List<PlayType> { PlayType.PAPER, PlayType.SPOCK } },
                { PlayType.PAPER, new List<PlayType> { PlayType.SCISORS, PlayType.LIZARD } },
                { PlayType.SCISORS, new List<PlayType> { PlayType.ROCK, PlayType.SPOCK } },
                { PlayType.LIZARD, new List<PlayType> { PlayType.SCISORS, PlayType.ROCK } },
                { PlayType.SPOCK, new List<PlayType> { PlayType.PAPER, PlayType.LIZARD } }
            };


            if (!loseConditions[playerChoice].Contains(CPUChoice))
            {
                Debug.Log("HUMAN WINS");
                return 1;
            }
            else
            {
                Debug.Log("CPU WINS");
                return 0;
            }
        }

        public void ShowPlays()
        {

        }

        public void SetGameType(bool classic)
        {
            IsClassic = classic;
        }
    }

}