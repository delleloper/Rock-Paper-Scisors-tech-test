using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Delleloper.RPSTechTest
{
    public class PlayButton : MonoBehaviour
    {
        public PlayType type;
        public Sprite[] sprites;
        [SerializeField] Image image;

        public void Start()
        {
            if (sprites.Length < (int)type)
            {
                image.sprite = sprites[(int)type];
            }
        }
    }

}