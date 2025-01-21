using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delleloper.RPSTechTest
{


    public class GameManager : MonoBehaviour
    {
        private int playerScore = 0;
        private int cpuScore = 0;
        private bool isClassic = true;


        public void Start()
        {
            
        }

        public void PlayerChoice(PlayType play)
        {

        }

        public PlayType GetCPUChoice()
        {
            if (isClassic)
            {
                return (PlayType)Random.Range(0, 2);
            }
            else
            {
                return (PlayType)Random.Range(0, 4);
            }
        }
    }

}