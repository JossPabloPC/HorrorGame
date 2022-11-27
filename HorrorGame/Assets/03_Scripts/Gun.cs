using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    public float damage=10f;
    public float range=100f;
    public float impactForce=10f;
    public Camera fpsCam;//referencia a la camara
    public ParticleSystem muzzFlash; 
    private bool canShoot=false;

    [SerializeField] private Transform pistolPosition;
    //public GameObject impactEffect;

    public Camera fpsCam;


    //Reloading
    public int maxAmmo=6;
    private int currentAmmo;
    public float reloadTime;
    [SerializeField]private bool isReloading=false;
    public Animator animatorWeapon;
    public Image reloadProgres;
    


    //Disparo rapido
    public float fireRate=15f;
    private float nextTimeFire =0f;
    [SerializeField] private bool pistol;


    private void Start() {
        currentAmmo=maxAmmo;
        pistolPosition.transform.position=this.transform.localPosition;
        reloadProgres.fillAmount=0;
    }
    /*
    onEnable()//En caso de que queramos aumentar el número de armas para evitar bugs
    {
        isReloading=false;
        animator.SetBool("Reload",false);
    }
    */
    // Update is called once per frame
    void Update()
    {
        if(isReloading){//si estamos recargando no queremos hacer todo lo demas
            PlayerMovement.pmInstance.canMove=true;
            return;        
        }
            if(Input.GetButtonUp("Fire2"))//Dejamos de apuntar
            {
                PlayerMovement.pmInstance.canMove=true;
                canShoot=false;
            }
            return;
        }
        if(currentAmmo<=0)//si nos acabamos la municion recargamos
        {
            StartCoroutine(Reload());
            return;
        }
       InputShoot();
    }

    private void InputShoot(){

         //Inputs
         if(Input.GetButton("Fire2"))//Apuntamos
         {
            //this.transform.SetParent(fpsCam.transform);
            PlayerMovement.pmInstance.canMove=false;
            canShoot=true;
            
         }
         if(Input.GetButtonUp("Fire2"))//Dejamos de apuntar
        {
            //this.transform.localPosition= pistolPosition.transform.position;
            //this.transform.SetParent(PlayerMovement.pmInstance.transform);
            PlayerMovement.pmInstance.canMove=true;
            canShoot=false;
            
        }
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeFire&&!pistol&&canShoot)//Disparos continuos(ametralladora) si podemos apuntar
        {
            nextTimeFire=Time.time+1f/fireRate;//cadencia de disparo por segundo
            Shoot();
        }
        if(Input.GetButtonDown("Fire1")&&pistol&&canShoot)//Disparos controlados (pistola) si podemos apuntar
        {
          
            Shoot();
        }
    }
    

    void Shoot()
    {
        muzzFlash.Play();//llamamos las particulas
        RaycastHit hit;//Lo que golpeamos con el raycast
        currentAmmo--;//cada vez que disparamos perdemos munición
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))//creamos y comprobamos el Raycast
        {
            Debug.Log(hit.transform.name);

       
        }
    }
    IEnumerator Reload ()
    {
        isReloading=true;//Se esta recargando
        Debug.Log("Reloading...");
        animatorWeapon.SetBool("Reload",true);
        yield return new WaitForSeconds(reloadTime);//esperamos n segundos a que revargue
        currentAmmo=maxAmmo;//volvemos a rellanar la municion al maximo
        animatorWeapon.SetBool("Reload",false);
        isReloading=false;//No se esta recargando
    }

        
    
    IEnumerator Reload ()
    {
        float timeTrans=0f;
        isReloading=true;//Se esta recargando
        Debug.Log("Reloading...");
        animatorWeapon.SetBool("Reload",true);
        while(timeTrans<reloadTime)
        {
            reloadProgres.fillAmount=Mathf.Lerp(0,1,timeTrans);
            reloadProgres.fillAmount=0;
            timeTrans+=Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(reloadTime);//esperamos n segundos a que recargue
        currentAmmo=maxAmmo;//volvemos a rellanar la municion al maximo
        animatorWeapon.SetBool("Reload",false);
        isReloading=false;//No se esta recargando
          
    }


}
