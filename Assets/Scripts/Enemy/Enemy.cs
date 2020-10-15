using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField]
    protected Vector2 moveDirection;
    [SerializeField]
    protected float timeLeftAlive;

    public void setLocation(float x, float y, Vector2 dir)
    {
        transform.position = new Vector3(x, y, 0);
        moveDirection = dir;
    }

    public abstract void randomSpawn();

}
