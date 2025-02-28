using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    private Animator shadowAnimator;

    [SerializeField] private GameObject playerSprite; // Reference to the Player sprite
    [SerializeField] private GameObject shadowSprite; // Reference to the Shadow sprite

    private bool isShadowForm = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the Animator components from the Player and Shadow sprites
        playerAnimator = playerSprite.GetComponent<Animator>();
        shadowAnimator = shadowSprite.GetComponent<Animator>();

        // Ensure only the Player sprite is visible at the start
        playerSprite.SetActive(true);
        shadowSprite.SetActive(false);
    }

    void Update()
    {
        // Move the PlayerContainer
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Update movement input
        moveInput = context.ReadValue<Vector2>();

        // Handle animations
        if (isShadowForm)
        {
            UpdateAnimator(shadowAnimator);
        }
        else
        {
            UpdateAnimator(playerAnimator);
        }
    }

    private void UpdateAnimator(Animator animator)
    {
        animator.SetBool("isWalking", moveInput.magnitude > 0);

        if (moveInput.magnitude > 0)
        {
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }

        if (moveInput.magnitude == 0)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
    }

    public void ToggleShadowForm()
    {
        isShadowForm = !isShadowForm;

        // Toggle visibility of Player and Shadow sprites
        playerSprite.SetActive(!isShadowForm);
        shadowSprite.SetActive(isShadowForm);

        // Sync animations between forms
        if (isShadowForm)
        {
            SyncAnimator(shadowAnimator, playerAnimator);
        }
        else
        {
            SyncAnimator(playerAnimator, shadowAnimator);
        }
    }

    private void SyncAnimator(Animator targetAnimator, Animator sourceAnimator)
    {
        // Sync walking state
        targetAnimator.SetBool("isWalking", sourceAnimator.GetBool("isWalking"));

        // Sync input values
        targetAnimator.SetFloat("InputX", sourceAnimator.GetFloat("InputX"));
        targetAnimator.SetFloat("InputY", sourceAnimator.GetFloat("InputY"));

        // Sync last input values
        targetAnimator.SetFloat("LastInputX", sourceAnimator.GetFloat("LastInputX"));
        targetAnimator.SetFloat("LastInputY", sourceAnimator.GetFloat("LastInputY"));
    }
}
