using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IReceiveDamage, IHeal
{
    public static PlayerManager instance;
    public int health;
    public bool hasKey;

    public Text hpTxt;

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
        hpTxt.text = health.ToString();
    }

    public void Damage()
    {
        health -= 10;
        hpTxt.text = health.ToString();
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
            SceneManager.LoadScene(0);
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
            hpTxt.text = health.ToString();
        }
    }
}

public interface IHeal
{
    void TakeFAK();
}
