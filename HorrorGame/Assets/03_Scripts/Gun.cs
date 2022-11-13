using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage=10f;
    public float range=100f;
    public float impactForce=10f;
    public Camera fpsCam;//referencia a la camara
    public ParticleSystem muzzFlash; 
    //public GameObject impactEffect;

    //Reloading
    public int maxAmmo=6;
    private int currentAmmo;
    public float reloadTime;
    [SerializeField]private bool isReloading=false;
    public Animator animatorWeapon;
    

    //Disparo rapido
    public float fireRate=15f;
    private float nextTimeFire =0f;
    [SerializeField] private bool pistol;

    private void Start() {
        currentAmmo=maxAmmo;
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
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeFire&&!pistol)//Disparos continuos(ametralladora)
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
        muzzFlash.Play();//llamamos las particulas
        RaycastHit hit;//Lo que golpeamos con el raycast
        currentAmmo--;//cada vez que disparamos perdemos munición
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))//creamos y comprobamos el Raycast
        {
            Debug.Log(hit.transform.name);

            //Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));//generamos las particulas


            /*
            if(hit.rigidbody)
            {
                hit.rigidbody.AddForce(hit.normal*impactForce);//LE añadimos una fuerza al objeto impactado
            }
            
            //Aqui va lo de hacer daño al enemigo
            
            Enemy enemy =hit.transform.GetComponent<Enemy>();
            if(enemy!=null)
            {
                enemy.takeDamage
            }
            */
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

}
