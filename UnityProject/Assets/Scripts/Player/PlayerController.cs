using UnityEngine;

namespace CyberSec
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed = 5f;
        public bool canMove = true;

        [Header("References")]
        public Rigidbody2D rb;
        public Animator animator;

        private Vector2 movement;

        private void Update()
        {
            if (!canMove) return;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (animator != null)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
        }

        private void FixedUpdate()
        {
            if (!canMove || rb == null) return;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        public void EnableMovement() => canMove = true;
        public void DisableMovement() => canMove = false;

        public void Teleport(Vector2 position)
        {
            if (rb != null) rb.position = position;
            else transform.position = position;
        }
    }
}
