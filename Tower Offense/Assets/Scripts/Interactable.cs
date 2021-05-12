using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public float interactionDelay = 2f;
    public Transform interactionTransform;
    public Color highlightColor;
    Color startColor;

    bool hasInteracted = false;
    float interactionTime;

    bool isFocus = false;
    Transform player;

    private void Start()
    {
        startColor = this.GetComponent<MeshRenderer>().material.color;
        interactionTime = interactionDelay;
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }

    public virtual void Interact()
    {
        // What to do if you click with right mouse
        Debug.Log("INTERACT");
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius)
        {
            this.GetComponent<MeshRenderer>().material.color = highlightColor;
        }
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        this.GetComponent<MeshRenderer>().material.color = startColor;
    }


    private void Update()
    {
        if (isFocus && !hasInteracted && Input.GetMouseButtonDown(1))
        {
            hasInteracted = true;
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            interactionTime = interactionDelay;
            if(distance <= radius)
            {
                Interact();
            }
        }
        interactionTime -= Time.deltaTime;
        if(interactionTime <= 0)
        {
            hasInteracted = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
        
    }
}
