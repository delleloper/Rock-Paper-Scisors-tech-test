using System;
using System.Collections;
using System.Collections.Generic;
using Delleloper.RPSTechTest;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame(bool regularGame)
    {
        GameManager.Instance.SetGameType(regularGame);
        SceneManager.LoadScene(1);
    }
}
