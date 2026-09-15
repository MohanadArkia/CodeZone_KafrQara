using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float maxDistance = 100f;
    public Camera cam;
    public ParticleSystem particle;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
        //FindFirstObjectByType<AudioManager>().Play("AkSound");
        // particle.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance)) {
            // Target target = hit.transform.GetComponent<Target>();
            // if (target != null)
            // {
            //     target.TakeDamage(damage);
            // }
            Debug.Log(hit.transform.name);
        }
    }
}