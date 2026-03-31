using UnityEngine;
using UnityEngine.InputSystem;

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

        float xValue = inputVector.x * moveSpeed * Time.deltaTime;
        float zValue = inputVector.y * moveSpeed * Time.deltaTime;
        transform.Translate(xValue, 0, zValue);

        float magnitude = inputVector.magnitude;
        animator.SetFloat("speed", magnitude);
        animator.SetBool("isRunning", isSprinting && magnitude > Mathf.Epsilon);
    }
}
