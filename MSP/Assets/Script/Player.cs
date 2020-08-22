using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int speed;

    Vector3 moveVelocity = Vector3.zero;

    void Update()
    {
        Move();
    }

    void Move()
    {
            
        if (Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = Vector3.right;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = Vector3.left;
        if (Input.GetAxisRaw("Vertical") > 0)
            moveVelocity = Vector3.up;
        else if (Input.GetAxisRaw("Vertical") < 0)
            moveVelocity = Vector3.down;
        


        transform.position += moveVelocity * speed * Time.deltaTime;
    }
}
