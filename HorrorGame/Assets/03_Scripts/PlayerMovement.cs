using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
//Movimiento jugador
    public static PlayerMovement pmInstance;//Singleton 
    [SerializeField]private float xInput, zInput;
    public CharacterController controller;
    private Vector3 move;
    public float speed=7f;
    public float sprintSpeed=11f;
    [SerializeField] private bool canSprint=true;
    public float jumpHeight=1.5f;
    public Slider sprintStamina;
    private float staminaDecrese=0.5f, staminaIncrease=0.8f;
    [SerializeField]
    private float sprintRecharge;


    //Gravedad
    private Vector3 velocity;
    public float gravity=-18.81f;
    
    //Ground CHECK
    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    public bool canMove=true;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    
    private void Awake() 
    {
        if (pmInstance != null && pmInstance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            pmInstance = this; 
        } 
    }



    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Comprobamos si tocamos el suelo

        if(isGrounded&&velocity.y<0){//Ajustamos la velocidad en Y al tocar el suelo
            velocity.y=-2f;
        }

        if(Input.GetButtonDown("Jump")&&isGrounded&&canMove)//brinco
        {
            velocity.y=Mathf.Sqrt(jumpHeight*-2*gravity);//ecuacion que nos indica la velocidad necesaria para llegar una altura requerida
        }

        xInput=Input.GetAxis("Horizontal");
        zInput=Input.GetAxis("Vertical");
        move = transform.right*xInput+transform.forward*zInput;//Calculamos la direccion de nuestro movimiento
        if(canMove)//Movimiento
        {
            controller.Move(move*speed*Time.deltaTime);//Aplicamos movimiento
        }
        
        velocity.y+=gravity*Time.deltaTime;//Calculamos la gravedad
        controller.Move(velocity*Time.deltaTime);//Aplicamos gravedad

        SprintInputs();
        
    }


    private void SprintInputs(){
        if(Input.GetKey(KeyCode.LeftShift)&&canSprint)//Sprint
        {
            sprintStamina.value-=staminaDecrese*Time.deltaTime;//Bajamos la barra de stamina
            controller.Move(move*sprintSpeed*Time.deltaTime);//Vamos mas rapido
            
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))//si dejamos de correr 
        {
            sprintStamina.value+=staminaIncrease*Time.deltaTime;//Recarga desde donde se quedo la barra  
        }
        if(sprintStamina.value<0.1f)//si agota su barra por completo
        {
            
            StartCoroutine(StaminaRecharge(sprintStamina.value));//tenemos que esperar hasta que se rellene por completo
        }
    }
    public IEnumerator StaminaRecharge(float staminaV)
    {
        float timeTrans=0;
        canSprint=false;
        while(timeTrans<sprintRecharge) 
        {
            sprintStamina.value=Mathf.Lerp(0,1,timeTrans/sprintRecharge);
            timeTrans+=Time.deltaTime;
            if(sprintStamina.value>=1)//hasta que no se halla rellenado la barra no podemos volver a correr
            {
                canSprint=true;
            }
        }
        
        yield return new WaitUntil(()=>canSprint);
        
        
    }


}
