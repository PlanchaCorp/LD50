using UnityEngine;
using UnityEngine.InputSystem;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Player {
[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable speed;
        private Rigidbody2D rb;
        private Vector2 direction = Vector2.zero;

        public void Start(){
            rb = GetComponent<Rigidbody2D>();
        }
        public void OnMove (InputValue input){
            this.direction = input.Get<Vector2>().normalized;
        }
        public void FixedUpdate(){
            this.rb.velocity = direction * speed.Value;
        }
    }
}
