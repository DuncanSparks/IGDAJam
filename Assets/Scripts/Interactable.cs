using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius = 3.2f;

    bool isFocus = false;
    bool hasInteracted = false;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform interactionTransform;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position,interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
                
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;

    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
