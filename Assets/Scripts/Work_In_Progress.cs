using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clean-up steps
//Step 1: CTRL+A (Highlight all code)
//Step 2: CTRL+K+D (In that order)

public class Work_In_Progress : MonoBehaviour
{
    // <access specifier> <data type> <variable name>
    public int lives = 3;
    public float rotationSpeed = 2;
    public float movementSpeed = 5;
    public float acceleration = 50f;
    public float deceleration = .1f;

    //objects default to "null"
    private Rigidbody2D rigid;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Before setting rigid" + rigid);
        rigid = GetComponent<Rigidbody2D>();
        Debug.Log("After setting rigid" + rigid);
    }

    // Update is called once per frame
    void Update()
    {
        //If user presses W
        if (Input.GetKey(KeyCode.W))
        {
            //Move up
            rigid.AddForce(transform.right* acceleration);
        }
        //If user presses S
        if (Input.GetKey(KeyCode.S))
        {
            //Move down
            rigid.AddForce(-transform.right * acceleration);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.rotation = transform.rotation * Quaternion.AngleAxis(rotationSpeed, Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = transform.rotation * Quaternion.AngleAxis(-rotationSpeed, Vector3.forward);
        }
        //Deceleration
        rigid.velocity += -rigid.velocity * deceleration;

       
    }
}
