using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class kbmmovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private float gravity = -9.8f;
    


    private CharacterController controller;
    
    private Vector2 aim;
    private Vector2 movement;
    private Vector3 playerVelocity;

    private Playerkeybinds playerkeybinds;
    private PlayerInput playerInput;
    private Animator animator;

    private void Awake() 
    {
        controller = GetComponent<CharacterController>();
        playerkeybinds = new Playerkeybinds();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
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
        if(!PauseMenu.isPaused)
        {
            HandleInput();
            HandleMovement();
            HandleRotation();
            animator.SetFloat("Speed", 0);
        }
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

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move (playerVelocity * Time.deltaTime);
        animator.SetFloat("Speed", 1);
        
    }

    
    void HandleRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(aim);
        Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }
    }

    //not understood but something about fixing where the character looks at 
    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
    
}
