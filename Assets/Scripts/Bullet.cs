using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public int damage;

    private Vector2 moveDirection;

    [SerializeField]
    private float moveSpeed = 1;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void Destroy()
    {
        BulletPool.bulletPoolInstanse.returnBullet(tag, gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity hitEntity = collision.gameObject.GetComponent<Entity>();


        if (hitEntity == null) return;
        if (hitEntity.tag == "Player" && tag == "Player") return;
        if (hitEntity.tag == "Enemy" && tag == "Enemy") return;

        hitEntity.Damage(damage);

        Destroy();
    }
}
