using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowFormController1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private Color normalColor; // Stores original color of the sprite
    private Color shadowColor; // Stores shadow form color

    [Header("Shadow Form Settings")]
    [SerializeField] private float shadowOpacity = 0.5f; // Opacity for shadow form
    [SerializeField] private Color shadowTint = new Color(0.2f, 0.2f, 0.2f, 1f); // Darker tint for shadow form

    [Header("Shadow Energy Settings")]
    [SerializeField] private float maxShadowEnergy = 100f; // Maximum shadow energy
    [SerializeField] private float energyDepletionRate = 10f; // Energy depletion rate per second
    [SerializeField] private float energyRechargeRate = 5f; // Energy recharge rate per second
    [SerializeField] private Slider shadowEnergyBar; // Reference to UI Slider

    private float currentShadowEnergy; // Current shadow energy
    public bool isShadowForm = false; // Tracks whether player is in shadow form

    private Collider2D playerCollider; // Reference to player's collider

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original color of the sprite
        normalColor = spriteRenderer.color;

        // Initialize shadow energy
        currentShadowEnergy = maxShadowEnergy;

        // Set up the energy bar
        if (shadowEnergyBar != null)
        {
            shadowEnergyBar.maxValue = maxShadowEnergy;
            shadowEnergyBar.value = currentShadowEnergy;
        }

        // Get the player's collider
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Toggle shadow form when Shift is pressed and there's energy
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentShadowEnergy > 0)
        {
            ToggleShadowForm();
        }

        // Handle energy depletion and recharge 
        //TODO: Will need to change to collecting items to gain energy
        if (isShadowForm)
        {
            DepleteEnergy();
        }
        else
        {
            RechargeEnergy();
        }

        // Update the energy bar
        if (shadowEnergyBar != null)
        {
            shadowEnergyBar.value = currentShadowEnergy;
        }
    }

    void ToggleShadowForm()
    {
        // Toggle between shadow and normal form
        isShadowForm = !isShadowForm;

        if (isShadowForm)
        {
            // Apply shadow form: darker tint and lower opacity
            shadowColor = shadowTint;
            shadowColor.a = shadowOpacity;
            spriteRenderer.color = shadowColor;

            // Disable collision with ShadowWall objects
            Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowWall"), true);
        }
        else
        {
            // Revert to normal form
            spriteRenderer.color = normalColor;

            // Re-enable collision with ShadowWall objects
            Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("ShadowWall"), false);
        }
    }

    void DepleteEnergy()
    {
        // Reduce energy over time
        currentShadowEnergy -= energyDepletionRate * Time.deltaTime;

        // If energy runs out, revert to normal form
        if (currentShadowEnergy <= 0)
        {
            currentShadowEnergy = 0;
            ToggleShadowForm();
        }
    }

    void RechargeEnergy()
    {
        // Recharge energy over time
        currentShadowEnergy += energyRechargeRate * Time.deltaTime;

        // Clamp energy to the maximum value
        currentShadowEnergy = Mathf.Clamp(currentShadowEnergy, 0, maxShadowEnergy);
    }
}