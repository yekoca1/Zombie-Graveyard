using System.Collections;
using System.Collections.Generic;  // bi sorun var aşağı yukarı hareket ediyo
using UnityEngine;

public class movePlayer : MonoBehaviour  // yüzünün baktığı yöne gitmesi için local rotation eklenmeli..!
{
    public int speed = 3;
    const float gravity = 9.8f;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();      
    }

    // Update is called once per frame
    void Update()
    {
        moving();   
    }

    Vector3 moveVector;
    

    private void moving()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,Input.GetAxis("Vertical")*speed*Time.deltaTime); // x yatay, y 0, z dikey
        moveVector = transform.TransformDirection(moveVector); // local rotation eklendi
        
        if(characterController.transform.position.y > 1.8f ) 
        {
            moveVector.y -= Time.deltaTime*gravity;  //yere basmadığında yere değene kadar y değerini yavaşça azaltır..!
        }

        characterController.Move(moveVector);  // Move yerine SimpleMove() kullanılırsa player yerçekiminden etkilenir ama zıplayamaz..! 
    }
}


 // Minimum height the character can be


