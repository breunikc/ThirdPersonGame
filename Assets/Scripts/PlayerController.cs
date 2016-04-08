using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rbody;
    public float moveSpeed = 0;
    public float rotationSpeed;
    public float jumpSpeed;
    public float distToGround;
    private bool grounded;
    private bool doubleJump;
    private bool isMoving;

	// Use this for initialization
    //  -called once at the start of the game
	void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        MoveChar();
        RotateChar();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rbody.AddForce(Vector3.up * 300);
            grounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !grounded && doubleJump)
        {
            rbody.AddForce(Vector3.up * 300);
            doubleJump = false;
        }

    }

    void RotateChar()
    {
        rotationSpeed = 100f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void MoveChar()
    {
        
        // Animation changes with Integer change
        //  - name: AnimationParam
        //  - values:
        //         0 - idle
        //         1 - walk
        //         2 - run
        //         3 - walk backwards
        //         4 - jump (unimplemented)
        //  
        // Character can only move forward or backward but can turn with the mouse
        //

        // ************** RUNNING KEY COMBINATIONS **********************
        // NOTE: need to be before walking combinations, otherwise they will never be called!
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKey(KeyCode.UpArrow))
        {
            // activate the animation
            animator.SetInteger("AnimationParam", 2);
            // set the speed and move the player
            moveSpeed = 7;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = true;

        }
        /**** SPRINT BACKWARDS **********************************************************************************************
        else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKey(KeyCode.DownArrow)) {
            // activate the animation
            animator.SetInteger("AnimationParam", 2);
            // set the speed and move the player
            moveSpeed = 5;
            transform.Translate(transform.forward * -moveSpeed * Time.deltaTime);
        }
        *********************************************************************************************************************/

        // ************** WALKING KEY COMBINATIONS **********************
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // activate the animation
            animator.SetInteger("AnimationParam", 1);
            // set the speed and move the player
            moveSpeed = 3;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = true;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // activate the animation
            animator.SetInteger("AnimationParam", 3);
            // set the speed and move the player
            moveSpeed = -3;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = true;
            
        }
        else
        {
            animator.SetInteger("AnimationParam", 0);
            moveSpeed = 0;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = false;

        }

    }

    void OnCollisionEnter(Collision hit)
    {
        grounded = true;
        doubleJump = true;
    }

    
}
