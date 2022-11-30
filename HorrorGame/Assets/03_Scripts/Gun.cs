using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public static Gun instance;

    public void Awake()
    {
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public float damage=10f;
    public float range=100f;
    public float impactForce=10f;
    public ParticleSystem muzzFlash; 
    //public GameObject impactEffect;
    public Camera fpsCam;
    public bool canShoot=false;


    //Reloading
    public int maxAmmo=6;
    [SerializeField]
    private int currentAmmo;
    public float reloadTime;
    [SerializeField]private bool isReloading=false;
    public Animator animatorWeapon;
    public Image reloadProgres;
    //public Image aim;//Aqui se pone la cruz de la mira



    //Disparo rapido
    public float fireRate=15f;
    private float nextTimeFire =0f;
    [SerializeField] private bool pistol;

    float timeTrans = 0f;


    // Update is called once per frame


    private void Start() {
        currentAmmo=maxAmmo;
        //pistolPosition.transform.position=this.transform.localPosition;
        reloadProgres.fillAmount=0;
        // aim.setActive(false);
    }
   
    // Update is called once per frame
    private void Update()
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

        if(currentAmmo==0)//si nos acabamos la municion recargamos
        {
            StartCoroutine(Reload());
            return;
        }
        
        
       InputShoot();
    }

     void InputShoot(){
         //Inputs
         if(Input.GetButton("Fire2"))//Apuntamos
         {
            //this.transform.SetParent(fpsCam.transform);
            PlayerMovement.pmInstance.canMove=false;
            //aim.setActive(true);
            canShoot=true;
            
         }
         if(Input.GetButtonUp("Fire2"))//Dejamos de apuntar
        {
            //this.transform.localPosition= pistolPosition.transform.position;
            //this.transform.SetParent(PlayerMovement.pmInstance.transform);
            PlayerMovement.pmInstance.canMove=true;
            //aim.setActive(false);
            canShoot=false;
            
        }
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeFire&&!pistol&&canShoot)//Disparos continuos(ametralladora) si podemos apuntar

        {
            nextTimeFire=Time.time+1f/fireRate;//cadencia de disparo por segundo
            Shoot();
        }
        if(Input.GetButtonDown("Fire1")&&pistol)//Disparos controlados (pistola)
        {
            
            Shoot();
        }
    }

    void Shoot()
    {

        muzzFlash.Play();
        RaycastHit hit;
        currentAmmo--;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))
        {
            Debug.Log(hit.transform.name);
            if(hit.rigidbody)
            {
                //hit.rigidbody.AddForce(hit.normal*impactForce);//LE añadimos una fuerza al objeto impactado
                if(hit.collider.GetComponent<IReceiveDamage>() != null)
                {
                    hit.collider.GetComponent<IReceiveDamage>().Damage();
                }
            }
            //Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));//generamos las particulas

        }

       
    }

    public void ReloadAmmo()
    {
        currentAmmo += 3;
    }

    public IEnumerator Reload ()
    {
        isReloading=true;//Se esta recargando
        Debug.Log("Reloading...");
        animatorWeapon.SetBool("isReloading",true);
        // animatorWeapon.SetTrigger("Reload");
        // animatorWeapon.SetBool("Idle", false);

        yield return new WaitForSeconds(2);
        while(timeTrans<reloadTime)
        {
            //reloadProgres.fillAmount=Mathf.Lerp(0f,1f,timeTrans/reloadTime);
            //Debug.Log(reloadProgres.fillAmount);
            timeTrans+=Time.deltaTime;
            
            // if(reloadProgres.fillAmount>=1f){
            //     Debug.Log("aki");
            //     currentAmmo=6;//volvemos a rellanar la municion al maximo
            //     // animatorWeapon.SetBool("isReloading",false);//desactivamos la animación de recarga
            //     animatorWeapon.SetBool("Idle", true);
            //     isReloading=false;//No se esta recargando
            //     reloadProgres.fillAmount=0;
            //     break;
            // }
        }
        Debug.Log("voy a salir");
        // Debug.Log("aki");
        //currentAmmo=6;//volvemos a rellanar la municion al maximo
        animatorWeapon.SetBool("isReloading",false);//desactivamos la animación de recarga
        // animatorWeapon.SetBool("Idle", true);
        isReloading=false;//No se esta recargando
        //reloadProgres.fillAmount=0;
        

    }
}
   
