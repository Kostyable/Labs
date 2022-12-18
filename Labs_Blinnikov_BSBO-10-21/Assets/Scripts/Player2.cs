using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private int _speed; // скорость
    private Rigidbody2D _rb; // компонент Rigidbody 2D
    private float _dir; // направление движения
    private Vector2 _moveDir; // вектор движения
    private Animator _anim;
    
    private States2 State // анимация
    {
        get { return (States2)_anim.GetInteger("state2"); }
        set {_anim.SetInteger("state2", (int)value);}
    }

    void Awake() // инициалиазция полей
    {
        _speed = 100;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move() // передвижение игрока
    {
        _dir = Input.GetAxis("Horizontal");
        if (_dir >= 0f)
        {
            State = States2.Right;
        }
        else
        {
            State = States2.Left;
        }
        _moveDir = new Vector2(_dir, 0);
        _rb.velocity = _moveDir * _speed * Time.fixedDeltaTime;
    }
}

public enum States2 // перечисление анимаций
{
    Right,
    Left
}
