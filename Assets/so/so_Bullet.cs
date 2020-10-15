using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Bullet type", menuName = "Bullet")]
public class so_Bullet : ScriptableObject
{
    public float size;
    public Sprite sprite;
    public float moveSpeed;
    public Color color;
    
}
