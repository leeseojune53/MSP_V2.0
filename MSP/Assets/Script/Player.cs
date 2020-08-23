using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Gamemanager manager;

    public int speed;

    public bool isRespawntime;

    Vector3 moveVelocity = Vector3.zero;

    private void Awake()
    {
        manager.Makestar();
    }
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
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || (collision.gameObject.tag == "Poop"&&!isRespawntime))
        {
                speed = 0;
                manager.GameOver();
            
        }
        if(collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            manager.Makepoop();
            isRespawntime = true;
            Invoke("Respawntimeset", 0.5f);
        }
    } 

    void Respawntimeset()
    {
        isRespawntime = false;
    }

}
