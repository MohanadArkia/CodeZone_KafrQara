using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float damage;
    float maxDistance = 100f;
    public Camera cam;
    public ParticleSystem particle;
    public Animator animator;

    void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
            animator.SetBool("isShooting", true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("isShooting", false);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        FindFirstObjectByType<AudioManager>().Play("AkSound");
        particle.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
