using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orentation;
    public Transform player;
    public Transform playerObj;
    public float rotationSpeed;
    public Transform combatLookAt;
    public enum CameraStyle
    {
        Basic,
        Combat
    }
    public CameraStyle currentStyle;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Vector3 viewDir = player.position - transform.position;
        //new Vector3(transform.position.x, transform.position.y, transform.position.z)
        orentation.forward = viewDir.normalized;
        if (currentStyle == CameraStyle.Basic)
        {
            
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 InputDir = orentation.forward * verticalInput + orentation.right * horizontalInput;
            if (InputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, InputDir.normalized, rotationSpeed);
            }
        }
        else if(currentStyle == CameraStyle.Combat)
        {
            Vector3 combatViewDir = combatLookAt.position - transform.position;
            orentation.forward = combatViewDir.normalized;
            player.forward = combatViewDir.normalized;
        }
        
    }
}
