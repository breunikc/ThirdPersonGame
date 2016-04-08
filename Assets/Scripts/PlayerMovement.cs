using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 0;
    public float rotationSpeed = 0;
    Vector3 movement;
    Animator animator;
    Rigidbody playerRigidbody;
    int floor;
    float camRayLength = 100f;
    bool grounded;
    bool doubleJump;

	// Use this for initialization
	void Start () {
        floor = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move();
        Jump();
        Rotate();

    }

	// Update is called once per frame
	void Update () {
	    
	}

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidbody.AddForce(Vector3.up * 300);
            grounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !grounded && doubleJump)
        {
            playerRigidbody.AddForce(Vector3.up * 150);
            doubleJump = false;
        }
    }

    void Move()
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

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // activate the animation
            animator.SetInteger("AnimationParam", 3);
            // set the speed and move the player
            moveSpeed = -3;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);

        }
        else
        {
            animator.SetInteger("AnimationParam", 0);
            moveSpeed = 0;
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);

        }
    }

    void Rotate()
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

    void OnCollisionEnter(Collision hit)
    {
        grounded = true;
        doubleJump = true;
    }

}
