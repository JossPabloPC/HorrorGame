using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSenitivity=100f;
    [SerializeField] private float mouseX,mouseY;
    private float xRotation=0f;
    public Transform playerBody;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX=Input.GetAxis("Mouse X")*mouseSenitivity*Time.deltaTime;//Coordenadas del mouse en x
        mouseY=Input.GetAxis("Mouse Y")*mouseSenitivity*Time.deltaTime;//cordenadas del mouse en y
        xRotation-=mouseY;//Rotacion en Y
        xRotation=Mathf.Clamp(xRotation,-90f,90f);//limitamos la rotación en Y
        transform.localRotation=Quaternion.Euler(xRotation,0f,0f);//aplicamos rotación en Y
        playerBody.Rotate(Vector3.up*mouseX);//aplicamos rotacion en X

    }
}
