using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour{

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private const string SCENE_NAME = "Terrarium";

    void Start(){
        startButton.onClick.AddListener(OnStartGame);
        exitButton.onClick.AddListener(OnExitGame);
    }

    private void OnExitGame()
    {
        Application.Quit();
    }

    private void OnStartGame(){
        SceneManager.LoadScene(SCENE_NAME);
    }
}
