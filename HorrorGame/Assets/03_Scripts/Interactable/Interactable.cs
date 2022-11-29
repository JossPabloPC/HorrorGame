using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public bool hasInteracted = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance < radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
        
    }

    public virtual void Interact()
    {
        Debug.Log("Inetractua");
    }
}
