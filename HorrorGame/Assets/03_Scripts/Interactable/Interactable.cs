using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;
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
            float distance = Vector3.Distance(PlayerManager.instance.transform.position, transform.position);
            if(distance < radius && Input.GetKeyDown(KeyCode.E))
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