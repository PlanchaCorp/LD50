using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlanchaCorp.LD50.ScriptableObjects;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private FloatVariable GameOverImmunity;
    [SerializeField]
    private IntVariable CurrentLevel;
    [SerializeField]
    private FloatVariable TotalXp;
    [SerializeField]
    private GameEventPublisher GameOverEvent;
    [SerializeField]
    private IntVariable GameOverCount;

    [SerializeField]
    private FloatVariable BackgroundFadeInTime;

    [SerializeField]
    private CanvasGroup GameOverCanvasGroup;
    [SerializeField]
    private Canvas GameOverCanvas;
    [SerializeField]
    private TextMeshProUGUI ScoreText;

    private int allyCount;
    private float endOfImmunity;
    private bool isGameOver;
    private float gameOverTime;
    private float timeSinceStart;


    public void Start() {
        GameOverCanvas.enabled = false;
        isGameOver = false;
        allyCount = 0;
        endOfImmunity = Time.time + GameOverImmunity.Value;
        timeSinceStart = 0;
        RefreshScore();
    }
    public void Update() {
        if (isGameOver) {
            float opacity = Mathf.Lerp(0, 1, (Time.time - gameOverTime) / BackgroundFadeInTime.Value);
            GameOverCanvasGroup.alpha = opacity;
        } else {
            timeSinceStart += Time.deltaTime;
        }
    }

    public void IncrementAllyCount() {
        allyCount++;
    }
    public void DecrementAllyCount() {
        allyCount--;
        if (allyCount <= GameOverCount.Value && Time.time > endOfImmunity && !isGameOver) {
            InitGameOver();
        }
    }

    public void RefreshScore() {
        ScoreText.text = CurrentLevel.Value + "\n" + (int)Mathf.Floor(TotalXp.Value) + "\n" + (int)Mathf.Floor(timeSinceStart);
    }

    public void InitGameOver() {
        GameOverCanvas.enabled = true;
        RefreshScore();
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
