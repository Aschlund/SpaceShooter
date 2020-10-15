using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected int HP;
    public int dealDamage;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float FireRate;
    [SerializeField]
    protected Rigidbody2D rb2d;
    [SerializeField]
    protected float rotationSpeed;


    //entity loses health equal to damage
    public void Damage(int takeDamage)
    {
        HP -= takeDamage;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
