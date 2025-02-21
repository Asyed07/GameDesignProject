using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 25f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed += 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed -= 10;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (!crouch)
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

}
