using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Vector3 moveVector;
    public float Speed = 2f;
    public float jumpForce = 7f;
    public float fastSpeed = 1f;
    private float realSpeed;

    private int direction = 1;
    private float Timer = 3;
    private bool flipRight = true;

    void Start()
    {
        Rigidbody= GetComponent<Rigidbody2D>();

        realSpeed = Speed;
    }
    void Update()
    {
        walk();
        Run();
        Jump();

        Timer += Time.deltaTime;

        if (Timer < 1)
        {
            if(Timer < 0.5)
                transform.position += new Vector3(2, 0) * Time.deltaTime * direction + new Vector3(0, 2) * Time.deltaTime;
            else
                transform.position += new Vector3(2, 0) * Time.deltaTime * direction - new Vector3(0, 2) * Time.deltaTime;
        }

        if (moveVector.x > 0 && !flipRight)
        {
            Flip();
        }
        else if (moveVector.x < 0 && flipRight)
        {
            Flip();
        }
        
    }
    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        if (moveVector.x > 0)
            direction = 1;
        else if(moveVector.x < 0)
            direction = -1;

        transform.position += moveVector * realSpeed * Time.deltaTime;        
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Timer = 0;        
        }          
    }    
    void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift)) 
        { 
          realSpeed= fastSpeed;
        }
        else
        {
            realSpeed = Speed;
        }
    }

    private void Flip()
    {
        flipRight= !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
        
}
