using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardActions : MonoBehaviour
{
    private CharacterController characterController;
    public float speedRun = 7f;
    public float speedWalk = 4f;
    private float speed = 4f;

    private Animator anim;


    void Start()
    {
        // Get components from Game Object
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        // If Input.GetAxis isn't equal to zero, then the character is moving
        // It should then either walk or run
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0) {
            if(Input.GetKey(KeyCode.LeftShift)) {   // if shift pressed, make run
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", true);
                speed = speedRun;                   // change speed accordingly
            } else {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsRunning", false);
                speed = speedWalk;
            }
        } else {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown("1")) {
            anim.SetTrigger("Boxing");
        }  
        if (Input.GetKeyDown("2")) {
            anim.SetTrigger("Kick");
        }

    
        // Move game object in the space with keyboard input
        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        characterController.Move(move*Time.deltaTime*speed);
        transform.rotation = Quaternion.LookRotation(move);

    }


}
