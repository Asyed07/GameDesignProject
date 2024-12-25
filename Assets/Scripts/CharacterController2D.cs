using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float JumpStrength = 500f;  // The force applied to the player when jumping
    [Range(0, 1)][SerializeField] private float CrouchSpeed = .4f;  // The percentage of max speed applied when crouching (0 = no speed, 1 = full speed)
    [Range(0, .3f)][SerializeField] private float SmoothMovement = .05f;  // The smoothing factor for movement transitions
    [SerializeField] private bool AirMovement = true;  // Allows character movement while in the air (default is false)
    [SerializeField] private LayerMask GroundLayer;  // Defines what layers are considered "ground" for the character
    [SerializeField] private Transform GroundCheckPosition;  // Reference to the ground check position to detect if the character is on the ground
    [SerializeField] private Transform CeilingCheckPosition;  // Reference to the ceiling check position to detect if there is a ceiling
    [SerializeField] private Collider2D CrouchCollider;  // Collider to disable when crouching to avoid collision issues

    const float GroundCheckRadius = .3f;  // The radius used to check for nearby ground objects
    private bool IsGrounded;  // A flag to check if the character is currently grounded
    const float CeilingCheckRadius = .3f;  // The radius used to check for ceilings
    private Rigidbody2D CharacterRigidbody;  // Reference to the Rigidbody2D component attached to the character
    private bool FacingRight = true;  // A flag to track the character's facing direction (right = true, left = false)
    private Vector3 Velocity = Vector3.zero;  // Variable used for smoothing the velocity transitions

    [Header("Events")]
    [Space]

    public UnityEvent LandEvent;  // Event triggered when the character lands
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent CrouchEvent;  // Event triggered when the character crouches or stands
    private bool WasCrouching = false;  // Tracks whether the character was previously crouching

    private void Awake()
    {
        CharacterRigidbody = GetComponent<Rigidbody2D>();  // Get reference to Rigidbody2D component

        if (LandEvent == null) LandEvent = new UnityEvent();  // Ensure the events are initialized
        if (CrouchEvent == null) CrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;  // Store previous grounded state
        IsGrounded = false;  // Reset grounded state

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckPosition.position, GroundCheckRadius, GroundLayer);  // Perform ground detection by checking nearby colliders
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)  // Ignore the player object itself
            {
                IsGrounded = true;  // Mark the character as grounded
                if (!wasGrounded) LandEvent.Invoke();  // Trigger the landing event if the character just landed
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)  // Check if the character can stand up (if there is a ceiling)
        {
            if (Physics2D.OverlapCircle(CeilingCheckPosition.position, CeilingCheckRadius, GroundLayer))  // If a ceiling is detected, force crouch
            {
                crouch = true;
            }
        }

        if (IsGrounded || AirMovement)  // Allow movement if grounded or if air control is enabled
        {
            if (crouch)  // Handle crouching logic
            {
                if (!WasCrouching)
                {
                    WasCrouching = true;  // Mark the character as crouching
                    CrouchEvent.Invoke(true);  // Trigger crouch event
                }

                move *= CrouchSpeed;  // Reduce movement speed while crouching

                if (CrouchCollider != null) CrouchCollider.enabled = false;  // Disable collider to prevent collision issues while crouching
            }
            else  // Handle uncrouching logic
            {
                if (CrouchCollider != null) CrouchCollider.enabled = true;  // Enable collider when not crouching

                if (WasCrouching)
                {
                    WasCrouching = false;  // Mark the character as not crouching
                    CrouchEvent.Invoke(false);  // Trigger uncrouch event
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, CharacterRigidbody.linearVelocity.y);  // Calculate and apply the target velocity for smooth movement
            CharacterRigidbody.linearVelocity = Vector3.SmoothDamp(CharacterRigidbody.linearVelocity, targetVelocity, ref Velocity, SmoothMovement);  // Apply the smooth movement

            if (move > 0 && !FacingRight) Flip();  // Flip the character direction if moving right while facing left
            else if (move < 0 && FacingRight) Flip();  // Flip the character direction if moving left while facing right
        }

        if (IsGrounded && jump)  // Handle jumping logic
        {
            IsGrounded = false;  // Mark the character as no longer grounded
            CharacterRigidbody.AddForce(new Vector2(0f, JumpStrength));  // Apply vertical jump force
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;  // Toggle the facing direction

        Vector3 theScale = transform.localScale;  // Flip the character's scale to mirror the sprite
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
