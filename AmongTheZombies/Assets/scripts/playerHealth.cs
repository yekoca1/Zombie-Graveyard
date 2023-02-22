using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private GameObject Button;    

    void Start()
    {
        currentHealth = maxHealth;     
    }

    void Awake()
    {
        Button = GameObject.FindWithTag("restart");
        Button.SetActive(false);
    }

    public void deductHealth(int damage)
    {
        currentHealth -= damage;
        Debug.Log("kalan can" + currentHealth);
        if(currentHealth <= 0)
        {
            killPlayer();
        }
    }

    public void addHealth(int value)
    {
        currentHealth += value;
        Debug.Log("can alındı");
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killPlayer()
    {
        Debug.Log("adam öldü aq");
        Button.SetActive(true);
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
    }
    
}
