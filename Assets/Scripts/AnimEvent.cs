using Delleloper.RPSTechTest.Common;
using UnityEngine;

namespace Delleloper.RPSTechTest
{
    public class AnimEvent : MonoBehaviour
    {
        [SerializeField] UIManager uIManager;
        public void AnimationEnded()
        {
            uIManager.AnimationEnded();
        }
        
        public void CountdownSound()
        {
            AudioManager.Instance.PlaySfx(SoundType.COUNTDOWN);
        }

        public void CountdownEndSound()
        {
            AudioManager.Instance.PlaySfx(SoundType.COUNTDOWN_END);
        }

        public void HumanWin()
        {
            AudioManager.Instance.PlaySfx(SoundType.WIN);
        }

        public void Humanlose()
        {
            AudioManager.Instance.PlaySfx(SoundType.LOSE);
        }

        public void Tie()
        {
            AudioManager.Instance.PlaySfx(SoundType.TIE);
        }

    }
}