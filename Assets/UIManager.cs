using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Delleloper.RPSTechTest;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI cpuScore;
    [SerializeField] private TextMeshProUGUI games;

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
