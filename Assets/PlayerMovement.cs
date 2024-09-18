using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCam;
    private Animator anim;

    public float velocity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCam = Camera.main.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        anim.SetBool("move", movement != Vector3.zero);

        movement = myCam.TransformDirection(movement);
        movement.y = 0;

        controller.Move(movement * Time.deltaTime * velocity);
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 10);
    
        } 

       
    }


}
