using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas HomeContainer;
    [SerializeField]
    private Canvas HowToPlayContainer;
    [SerializeField]
    private Canvas CreditsCanvas;

    public void Start() {
        HomeContainer.enabled = true;
        HowToPlayContainer.enabled = false;
        CreditsCanvas.enabled = false;
    }


    public void GoToHowToPlay()
    {
        HomeContainer.enabled = false;
        HowToPlayContainer.enabled = true;
        CreditsCanvas.enabled = false;
    }
    public void GoToCredits() {
        HomeContainer.enabled = false;
        HowToPlayContainer.enabled = false;
        CreditsCanvas.enabled = true;
    }

    public void GoBack() {
        HomeContainer.enabled = true;
        HowToPlayContainer.enabled = false;
        CreditsCanvas.enabled = false;
    }
    public void StartGame() {
        StartCoroutine(StartGame(1.1f));
    }

    private IEnumerator StartGame(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
}
