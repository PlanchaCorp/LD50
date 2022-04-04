using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class SpikeSpell : GenericInstantSpell
    {
        [SerializeField]
        private AudioSource spikeSound;
        public void Cast(SpikeSpellType spikeSpell, Vector2 castPosition)
        {
            if (spikeSound != null) {
                spikeSound.Play();
            }
            base.Cast(spikeSpell);
            // Setting the scale (range + angle)
            float scaleX = spikeSpell.Range * transform.localScale.x;
            float scaleY = (spikeSpell.Angle / 45f) * transform.localScale.y * scaleX;
            transform.localScale = new Vector2(scaleX, scaleY);
            // Setting the angle
            Vector2 direction = castPosition - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
