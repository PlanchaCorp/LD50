using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource ClickSound;
    [SerializeField]
    private AudioSource GameStartSound;
    [SerializeField]
    private AudioSource ClickBackSound;

    public void EmitClickSound() {
        ClickSound.Play();
    }

    public void EmitGameStartSound() {
        GameStartSound.Play();
    }

    public void EmitClickBackSound() {
        ClickBackSound.Play();
    }
}
