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