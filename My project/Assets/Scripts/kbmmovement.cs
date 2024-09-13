using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class kbmmovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float rotationSmoothing = 1000f;

    private CharacterController controller;
    
    private Vector2 aim;
    private Vector2 movement;
    private Vector3 playerVelocity;

    private Playerkeybinds playerkeybinds;
    private PlayerInput playerInput;

    private void Awake() 
    {
        controller = GetComponent<CharacterController>();
        playerkeybinds = new Playerkeybinds();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable() 
    {
        playerkeybinds.Enable();
    }

    private void OnDisable() 
    {
        playerkeybinds.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
    }

    void HandleInput()
    {
        movement = playerkeybinds.Controlkbm.Movement.ReadValue<Vector2>();
        aim = playerkeybinds.Controlkbm.Aim.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);


        // in case there's vertical movement
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleRotation()
    {

    }
}
