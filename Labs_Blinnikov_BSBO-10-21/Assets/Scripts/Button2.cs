using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    private float _distance; // дистанция до игрока
    private GameObject _player; // игрок
    private Table _table; // табличка
    
    public delegate void OnPress(); // делегат

    public event OnPress OnPressEvent; // событие

    void Awake() // инициализация полей
    {
        _table = GameObject.Find("Table").GetComponent<Table>();
        _player = GameObject.Find("Player2");
    }

    void Update()
    {
        Trigger();
    }

    void Trigger() // срабатывание кнопки при нажатии клавиши E
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        if (_distance < 1.4f && Input.GetKeyDown(KeyCode.E))
        {
            OnPressEvent += _table.Light;
            OnPressEvent();
        }
    }
}
