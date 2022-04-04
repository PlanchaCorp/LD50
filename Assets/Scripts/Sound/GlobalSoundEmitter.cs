using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundEmitter : MonoBehaviour
{
    [SerializeField]
    private AudioSource LevelUpSound;
    [SerializeField]
    private AudioSource UpgradeSkillSound;
    [SerializeField]
    private AudioSource UnavailableOptionSound;

    public void EmitLevelUpSound() {
        LevelUpSound.Play();
    }

    public void EmitUpgradeSkillSound() {
        UpgradeSkillSound.Play();
    }

    public void EmitUnavailableOptionSound() {
        UnavailableOptionSound.Play();
    }
}
