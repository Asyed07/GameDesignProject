using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; 
    public float runSpeed = 25f;

    float horizontalMove = 0f; // Stores the current horizontal movement input
    bool jump = false; // Tracks whether the player is trying to jump
    bool crouch = false; // Tracks whether the player is crouching

    void Update()
    {
        // Get horizontal input (-1 for left, 1 for right) and multiply by run speed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) // If Left Shift is pressed, temporarily increase run speed (sprint)
        {
            runSpeed += 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // When Left Shift is released, return to normal run speed
        {
            runSpeed -= 10;
        }
        
        if (Input.GetButtonDown("Jump")) // Check if the jump button was pressed
        {
            
            if (!crouch) // Only allow jumping if the player is not crouching
            {
                jump = true;
                animator.SetBool("IsJumping", true); // Trigger jump animation
            }
        }

        if (Input.GetButtonDown("Crouch")) // Check if crouch button is pressed
        {
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))// Check if crouch button is released
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false); // Stop jump animation
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching); // Update crouch animation
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
