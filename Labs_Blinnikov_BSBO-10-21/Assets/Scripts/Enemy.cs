using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : Entity // класс врагов
{
    private int _health;
    protected int Health
    {
        get => _health;
        set => _health = value;
    }
    
    [SerializeField] private int damage; // сила атаки
    protected int Damage
    {
        get => damage;
        set => damage = value;
    }
    
    [SerializeField] private Entity target; // цель атаки
    protected Entity Target
    {
        get => target;
        set => target = value;
    }
    
    [SerializeField] private float radius; // радиус обнаружения
    protected float Radius
    {
        get => radius;
        set => radius = value;
    }

    public override void Damagable(int enemyDamage) // переопределение метода
    {
        _health -= enemyDamage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
