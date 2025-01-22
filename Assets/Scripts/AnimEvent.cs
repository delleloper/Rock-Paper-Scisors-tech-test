using System.Collections;
using System.Collections.Generic;
using Delleloper.RPSTechTest;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    public void AnimationEnded()
    {
        uIManager.AnimationEnded();
    }
}
