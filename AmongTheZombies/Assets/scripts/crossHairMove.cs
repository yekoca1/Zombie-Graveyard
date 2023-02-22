using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossHairMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.position = new Vector3(transform.position.x + movement.x * speed * Time.deltaTime, transform.position.y + movement.y * speed * Time.deltaTime, transform.position.z);
    }
}
