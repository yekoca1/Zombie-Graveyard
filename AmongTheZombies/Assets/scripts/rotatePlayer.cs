using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour
{
    public float sensivity = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayerBody();
    }
    public float rotateY;
    public float rotateX;

    public void rotatePlayerBody()
    {
        rotateY += sensivity*Input.GetAxis("Mouse Y")*-1;
        rotateX += sensivity*Input.GetAxis("Mouse X");
        rotateY = Mathf.Clamp(rotateY,-60, 20);  // y ekseninde dönmesini kısıtladık..!

        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);

    }
}
