using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        Debug.Log("OPEN THE DOORS!");
        animator.Play("Open");
    }
}
