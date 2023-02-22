using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectItems : MonoBehaviour
{
    playerHealth _pHealth;
    Shoot shoot;
    private GameObject mesaj;

    void Start()
    {
        _pHealth = GetComponent<playerHealth>();
        shoot = GetComponent<Shoot>();
        mesaj = GameObject.FindGameObjectWithTag("mesaj");
        mesaj.SetActive(false);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("can"))
        {
            _pHealth.addHealth(10);
            Debug.Log("mevcut can : " + _pHealth.getHealth());
            other.gameObject.SetActive(false);
        }

        else if(other.CompareTag("charger"))
        {
            shoot.reload();
            Debug.Log("Şarjör alındı, kalan mermi :" + shoot.getBullet());
            other.gameObject.SetActive(false);
        }

        else if(other.CompareTag("Finish"))
        {
            mesaj.SetActive(true);
            CharacterController characterController = GetComponent<CharacterController>();
            characterController.enabled = false;
        }
    }
}
