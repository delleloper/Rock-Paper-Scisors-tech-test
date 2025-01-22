using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Delleloper.RPSTechTest
{
    public class GameManager : MonoBehaviour
    {
        public bool IsClassic { get; private set; } = true;
        public string AnimationTrigger { get; private set; }
        public static GameManager Instance;
        public int Games { get; private set; } = 5;
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
        public int GetResult(PlayType human, PlayType cpu)
        {
            Debug.Log($"HUMAN PLAYS: {Enum.GetName(typeof(PlayType), human)} ");
            Debug.Log($"CPU PLAYS: {Enum.GetName(typeof(PlayType), cpu)} ");
            if (human == cpu)
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


            if (!loseConditions[human].Contains(cpu))
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
        public void SetGameType(bool classic)
        {
            IsClassic = classic;
        }

        public void GameOver()
        {
            Debug.Log("GAME OVER");
            Debug.Log(onGameOver.GetPersistentEventCount());
            onGameOver.Invoke();
        }

        public void DecreaseGamesCount()
        {
            if (Games == 0)
            {
                GameOver();
            }
            else
            {
                Games -= 1;
            }
        }

        public void SetGames(int value)
        {
            Games = value;
        }
    }

}