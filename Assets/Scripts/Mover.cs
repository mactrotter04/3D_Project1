using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Mover : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float runSpeedMultiplier = 2f;

    Animator animator;
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction sprintAction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = FindFirstObjectByType<Animator>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        sprintAction = playerInput.actions["Sprint"];
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }


    void MovePlayer()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        bool isSprinting = sprintAction.IsPressed();
        float speed = isSprinting ? moveSpeed * runSpeedMultiplier : moveSpeed;

        float xValue = inputVector.x * speed * Time.deltaTime;
        float zValue = inputVector.y * speed * Time.deltaTime;
        transform.Translate(xValue, 0, zValue, Space.World);

        float magnitude = inputVector.magnitude;
        animator.SetFloat("speed", magnitude);
        animator.SetBool("isRunning", isSprinting && magnitude > Mathf.Epsilon);
        Vector3 move = new Vector3(inputVector.x, 0f, inputVector.y);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }
    }


    
    
}

