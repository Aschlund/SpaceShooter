using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private Vector2 moveAmount;
    private float cooldown;

    private Vector3 bulletDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        bulletDirection = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //movement
        moveAmount += new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);
        Vector2 moveDiff = moveAmount * Time.deltaTime * 8;
        transform.position += (Vector3)moveDiff;


        moveAmount -= moveDiff;

        rb2d.rotation += rotationSpeed;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = FireRate;
            Fire();
        }
        //Debug.Log(transform.position.x + " " + transform.position.y);
    }
    
    private void Fire()
    {
        GameObject bul = BulletPool.bulletPoolInstanse.GetBullet("Player");
        bul.transform.position = transform.position;
        bul.GetComponent<Bullet>().SetMoveDirection(new Vector2(0, 1));
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy other = collision.gameObject.GetComponent<Enemy>();

        if (other == null) return;
        //if enemy ship is hit, damage both the player and the enemy
        if(other.tag == "Enemy") {
            Damage(other.dealDamage);
            other.Damage(dealDamage);
        }
    }
}
