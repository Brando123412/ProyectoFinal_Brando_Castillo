using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraMovementController : MonoBehaviour
{
    public float movementSpeed = 5f;  
    public Vector2[] cameraLimits ; 

    private Vector2 movementInput;

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = movementInput.y*-1;
        float verticalInput = movementInput.x;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, cameraLimits[0].x, cameraLimits[1].x);
        newPosition.z = Mathf.Clamp(newPosition.z, cameraLimits[0].y, cameraLimits[1].y);

        transform.position = newPosition;

        // Movimiento vertical
        float verticalMovement = Keyboard.current[Key.Q].ReadValue() - Keyboard.current[Key.E].ReadValue();
        float newVerticalPosition = transform.position.y + verticalMovement * movementSpeed * Time.deltaTime;
        newVerticalPosition = Mathf.Clamp(newVerticalPosition,8, 20);

        transform.position = new Vector3(transform.position.x, newVerticalPosition, transform.position.z);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
