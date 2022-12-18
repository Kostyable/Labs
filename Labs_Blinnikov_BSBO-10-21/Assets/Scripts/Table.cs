using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    private Animator _anim;
    private bool _isLight; // наличие света
    private Button2 _button; // кнопка
    
    private States3 State // анимация
    {
        get { return (States3)_anim.GetInteger("state3"); }
        set {_anim.SetInteger("state3", (int)value);}
    }

    void Awake() // инициализация полей
    {
        _anim = GetComponent<Animator>();
        _button = GameObject.Find("Button").GetComponent<Button2>();
    }

    public void Light() // свечение таблички
    {
        switch (_isLight)
        {
            case false:
                State = States3.WithLight;
                _isLight = true;
                break;
            case true:
                State = States3.WithoutLight;
                _isLight = false;
                break;
        }
        _button.OnPressEvent -= Light;
    }
}

public enum States3 // перечисление анимаций
{
    WithoutLight,
    WithLight
}