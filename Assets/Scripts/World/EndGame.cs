using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlanchaCorp.LD50.ScriptableObjects;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private FloatVariable GameOverImmunity;
    [SerializeField]
    private GameEventPublisher GameOverEvent;

    [SerializeField]
    private FloatVariable BackgroundFadeInTime;

    [SerializeField]
    private CanvasGroup GameOverCanvasGroup;

    private int allyCount;
    private float endOfImmunity;
    private bool isGameOver;
    private float gameOverTime;


    public void Start() {
        isGameOver = false;
        allyCount = 0;
        endOfImmunity = Time.time + GameOverImmunity.Value;
    }
    public void Update() {
        if (isGameOver) {
            float opacity = Mathf.Lerp(0, 1, (Time.time - gameOverTime) / BackgroundFadeInTime.Value);
            GameOverCanvasGroup.alpha = opacity;
        }
    }

    public void IncrementAllyCount() {
        allyCount++;
    }
    public void DecrementAllyCount() {
        allyCount--;
        if (allyCount <= 0 && Time.time > endOfImmunity && !isGameOver) {
            InitGameOver();
        }
    }

    public void InitGameOver() {
        isGameOver = true;
        gameOverTime = Time.time;
        GameOverEvent.Raise(new GameEvent());
    }

    public void Replay() {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
