//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage=10f;
    public float range=100f;
    public float impactForce=10f;
    public ParticleSystem muzzFlash; 
    //public GameObject impactEffect;
    public Camera fpsCam;
    //Disparo rapido
    public float fireRate=15f;
    private float nextTimeFire =0f;
    [SerializeField] private bool pistol;

    // Update is called once per frame
    void Update()
    {
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
        muzzFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range))
        {
            Debug.Log(hit.transform.name);
            if(hit.rigidbody)
            {
                hit.rigidbody.AddForce(hit.normal*impactForce);//LE añadimos una fuerza al objeto impactado
            }
            //Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));//generamos las particulas

            //Aqui va lo de hacer daño al enemigo
            /*
            Enemy enemy =hit.transform.GetComponent<Enemy>();
            if(enemy!=null)
            {
                enemy.takeDamage
            }
            */
        }
    }

}
