using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movimiento jugador
    [SerializeField]private float xInput, zInput;
    public CharacterController controller;
    public float speed=12f;
    public float jumpHeight=3;

    //Gravedad
    [SerializeField] private Vector3 velocity;
    public float gravity=-9.81f;
    
    //Ground CHECK
    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Comprobamos si tocamos el suelo

        if(isGrounded&&velocity.y<0){//Ajustamos la velocidad en Y al tocar el suelo
            velocity.y=-2f;
        }
        if(Input.GetButtonDown("Jump")&&isGrounded)//brinco
        {
            velocity.y=Mathf.Sqrt(jumpHeight*-2*gravity);//ecuacion que nos indica la velocidad necesaria para llegar una altura requerida
        }
        xInput=Input.GetAxis("Horizontal");
        zInput=Input.GetAxis("Vertical");
        Vector3 move = transform.right*xInput+transform.forward*zInput;//Calculamos la direccion de nuestro movimiento
        controller.Move(move*speed*Time.deltaTime);//Aplicamos movimiento
        velocity.y+=gravity*Time.deltaTime;//Calculamos la gravedad
        controller.Move(velocity*Time.deltaTime);//Aplicamos gravedad
    
    }
  
}
