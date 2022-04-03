using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class SpikeSpell : GenericInstantSpell
    {
        public void Cast(AbstractSpellType spikeSpell, Vector2 castPosition)
        {
            base.Cast(spikeSpell);
            // Setting the angle
            Vector2 direction = castPosition - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
