using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowFormController : MonoBehaviour
{
  private PlayerMovement playerMovement;
  
  void Start()
  {
    // Get the PlayerMovement component from the parent object
    playerMovement = GetComponentInParent<PlayerMovement>();
  }
  
  void Update()
  {
    // Check if the Control key is pressed
    if (Keyboard.current.ctrlKey.wasPressedThisFrame) // Using Unity's Input System
    {
      playerMovement.ToggleShadowForm();
    }
  }
}
