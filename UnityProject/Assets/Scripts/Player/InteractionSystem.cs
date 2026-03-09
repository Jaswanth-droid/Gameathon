using UnityEngine;

namespace CyberSec
{
    public class InteractionSystem : MonoBehaviour
    {
        [Header("Settings")]
        public float interactionRange = 2f;
        public LayerMask interactionLayer;
        public KeyCode interactKey = KeyCode.E;

        [Header("UI")]
        public GameObject interactionPrompt;

        private Collider2D currentTarget;

        private void Update()
        {
            CheckForInteractables();

            if (currentTarget != null && Input.GetKeyDown(interactKey))
            {
                Interact(currentTarget.gameObject);
            }
        }

        private void CheckForInteractables()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, interactionRange, interactionLayer);

            if (hit != null && hit != currentTarget)
            {
                currentTarget = hit;
                if (interactionPrompt) interactionPrompt.SetActive(true);
            }
            else if (hit == null && currentTarget != null)
            {
                currentTarget = null;
                if (interactionPrompt) interactionPrompt.SetActive(false);
            }
        }

        private void Interact(GameObject target)
        {
            IInteractable interactable = target.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
                if (interactionPrompt) interactionPrompt.SetActive(false);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactionRange);
        }
    }

    public interface IInteractable
    {
        void OnInteract();
    }
}
