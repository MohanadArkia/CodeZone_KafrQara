using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 MovementInputVector;
    float speed = 7f;
    float rotationSpeed = 720f;
    Rigidbody rigidBody;
    
    void OnMove(InputValue inputValue)
    {
        MovementInputVector = inputValue.Get<Vector2>();
    }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 changePosition = new Vector3(MovementInputVector.x, 0f, MovementInputVector.y) * speed;

        // transform.position = transform.position + changePosition * Time.fixedDeltaTime;

        Vector3 velocity = rigidBody.linearVelocity;
        velocity.x = MovementInputVector.x * speed;
        velocity.z = MovementInputVector.y * speed;

        if (changePosition != Vector3.zero)
        {
            Quaternion rotateTo = Quaternion.LookRotation(changePosition, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationSpeed * Time.deltaTime);
        }
        rigidBody.linearVelocity = velocity;
    }
}