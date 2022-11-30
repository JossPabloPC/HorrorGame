using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IReceiveDamage, IHeal
{
    public static PlayerManager instance;
    public int health;
    public bool hasKey;

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

    private void Start()
    {
        hasKey = false;
    }

    public void Damage()
    {
        health -= 10;
    }

    public void PickedKey()
    {
        hasKey = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 11)
        {
        }
    }

    public void TakeFAK()
    {
        if(health >= 100)
        {
            Debug.Log("Sacoles");
        }
        else
        {
            health += 10;
        }
    }
}

public interface IHeal
{
    void TakeFAK();
}
