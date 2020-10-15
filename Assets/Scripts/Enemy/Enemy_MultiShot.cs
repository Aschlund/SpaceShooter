using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MultiShot : Enemy
{
    [SerializeField]
    private int bulletsAmount;

    [SerializeField]
    private float startAngle, endAngle;

    private Vector2 bulletMoveDirection;

    [SerializeField]
    private float xMovement;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, FireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -5)
            xMovement = 1;
        else if(transform.position.x > 5)
            xMovement = -1;

        transform.Translate(new Vector3(xMovement, -0.4f, 0) * moveSpeed * Time.deltaTime);
    }
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet("Enemy");
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    public override void randomSpawn()
    {
        float randomX = Random.value * 12 - 6;

        setLocation(randomX, 5, new Vector2(0, 0));
    }
}
