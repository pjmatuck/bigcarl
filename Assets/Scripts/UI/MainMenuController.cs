using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    VisualElement visualElement;

    Button startButton;
    Button creditsButton;
    Button quitButton;
    void Start()
    {
        visualElement = GetComponent<UIDocument>().rootVisualElement;

        startButton = visualElement.Q<Button>("StartButton");
        creditsButton = visualElement.Q<Button>("CreditsButton");
        quitButton = visualElement.Q<Button>("QuitButton");

        startButton.clicked += OnStartClicked;
        quitButton.clicked += OnQuitClicked;
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

    private void OnStartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    void OnDestroy()
    {
        startButton.clicked -= OnStartClicked;
        quitButton.clicked -= OnQuitClicked;
    }
}
