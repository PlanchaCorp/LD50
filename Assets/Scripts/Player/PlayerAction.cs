using UnityEngine;
using UnityEngine.InputSystem;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Spell;

namespace PlanchaCorp.LD50.Scripts.Player {
[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable speed;
        [SerializeField]
        private SpellBook spellBook;
        private Rigidbody2D rb;
        private Vector2 direction = Vector2.zero;

        public void Start(){
            rb = GetComponent<Rigidbody2D>();
            CastPassiveSpell();
        }
        public void OnMove (InputValue input){
            this.direction = input.Get<Vector2>().normalized;
        }
        public void FixedUpdate(){
            this.rb.velocity = direction * speed.Value;
        }

        private void CastPassiveSpell(){
            GameObject passiveSpell = spellBook.spells[0];
            GameObject spellCasted = Instantiate(passiveSpell,this.transform);
            spellCasted.GetComponent<SpellAction>().cast(0,15,1);
        }
    }
}
