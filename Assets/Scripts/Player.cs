using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Shoot shoot;

    [SerializeField] float moveSpeed;
    [SerializeField] float leftPadding;
    [SerializeField] float rightPadding;
    [SerializeField] float topPadding;
    [SerializeField] float bottomPadding;

    Vector3 move;
    Vector2 moveInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
        shoot = GetComponent<Shoot>();
    }

    void Start()
    {
        InitializeCamera();
    }

   
    void Update()
    {
        Movement();
    }

    void InitializeCamera()
    {
        Camera mainCamera = Camera.main;

        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Movement()
    {
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x + move.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + move.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);
        move = moveInput * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();        
    }

    void OnFire(InputValue value)
    {
        if(shoot != null)
        {
            shoot.isFiring = value.isPressed;
        }
    }
}
