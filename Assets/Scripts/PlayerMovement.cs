using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 MovementInputVector;
    Vector2 MouseInputVector;
    float speed = 7f;
    Rigidbody rigidBody;
    
    float mouseX, mouseY;
    float xMouseSensitivity = 30f;
    float yMouseSensitivity = 30f;

    float xRotation;
    float minAngle = -80f;
    float maxAngle = 80f;

    public Camera cam;


    public WeaponSway sway;
    // public Animator weaponAnimator;

    void MoveMouse()
    {
        mouseX = MouseInputVector.x;
        mouseY = MouseInputVector.y;

        xRotation -= mouseY * Time.deltaTime * yMouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xMouseSensitivity);
    }

    void OnLook(InputValue inputValue)
    {
        MouseInputVector = inputValue.Get<Vector2>();
        sway.SetLookInput(MouseInputVector);
    }

    void OnMove(InputValue inputValue)
    {
        MovementInputVector = inputValue.Get<Vector2>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        // weaponAnimator = transform.Find("ActiveWeapon").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
 
        Vector3 velocity = rigidBody.linearVelocity;
        velocity.x = (transform.right * MovementInputVector.x + transform.forward * MovementInputVector.y).x * speed;
        
        velocity.z = (transform.right * MovementInputVector.x + transform.forward * MovementInputVector.y).z * speed;
        
        MoveMouse();


        rigidBody.linearVelocity = velocity;
    }
}

/*
Gun.cs



using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float distance = 100f;
    public Camera cam;
    public ParticleSystem particle;

    void OnAttack(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        FindFirstObjectByType<AudioManager>().Play("AkSound");
        particle.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}


*/


/*
Target.cs


using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 3f);   
    }
}

*/