using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHealth : MonoBehaviour
{
    public int startHealth = 100;
    private int currentHealth;
    
    void Start()
    {
        currentHealth = startHealth;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
            //TODO zombiyi öldür
            Debug.Log("Zombi öldü." + currentHealth);
        }  
        Debug.Log("Zombi hasar aldı." + currentHealth);
    }

    
    void Update()
    {
        
    }
}
