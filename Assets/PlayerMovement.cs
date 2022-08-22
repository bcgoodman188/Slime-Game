using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 1000f;
    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update() {
        //controller.Move();
        //Not recommended to move character inside of update method
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Debug.log will show code response in console
        //do{

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
            //canDoubleJump = false;
        //)while(canDoubleJump != false)
    }

    public void OnLanding () {
        jump = false;
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate () {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //Fixed delta time will cause the character to move THE SAME SPEED, no matter how often the function is called.
    }
}
