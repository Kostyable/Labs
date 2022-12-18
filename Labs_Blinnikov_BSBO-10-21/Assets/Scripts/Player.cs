using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] private int health; // здоровье
    private Transform _target; // цель движения
    private Animator _anim;
    private Text _hp;
    private Text _timer;
    private float _time; // время
    private Text _result;
    private bool _playerIsStop; // остановка игрока
    private bool _timeIsStop; // остановка времени
    
    private States State // анимация
    {
        get { return (States)_anim.GetInteger("state"); }
        set {_anim.SetInteger("state", (int)value);}
    }
    
    private void Awake() // инициализация полей
    {
        if (health == 0)
        {
            health = 100;
        }

        if (Speed == 0)
        {
            Speed = 150;
        }
        _target = GameObject.Find("Point").transform;
        Rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _hp = GameObject.Find("HP").GetComponent<Text>();
        _timer = GameObject.Find("Timer").GetComponent<Text>();
        _time = 60;
        _result = GameObject.Find("Result").GetComponent<Text>();
    }

    private void Update()
    {
        if (!_timeIsStop) // таймер
        {
            _time -= Time.deltaTime;
            if (_time <= 0) // победа
            {
                _hp.text = "";
                _timer.text = "";
                _result.text = "YOU WIN!";
                Time.timeScale = 0f;
                _playerIsStop = true;
                _timeIsStop = true;
            }
            else
            {
                Timer();
            }
        }
        if (!_playerIsStop)
        {
            _hp.text = "HP: " + health;
            
            // цель, привязанная к положению мыши
            _target.position = new Vector2(Input.mousePosition.x - Screen.width / 2f, Input.mousePosition.y - Screen.height / 2f);
            
            Move(_target);
        }
    }
    public override void Damagable(int enemyDamage)
    {
        health -= enemyDamage;
        if (health <= 0) // поражение
        {
            health = 0;
            _hp.text = "HP: " + 0;
            State = States.Dead;
            Rb.constraints = RigidbodyConstraints2D.FreezePosition;
            _result.text = "YOU LOSE!";
            Time.timeScale = 0f;
            _playerIsStop = true;
            _timeIsStop = true;
        }
        else // урон
        {
            State = States.Damagable;
            StartCoroutine(ResetAnim());
        }
        
    }

    private IEnumerator ResetAnim() //таймер смены анимации
    {
        yield return new WaitForSeconds(0.3f);
        State = States.Idle;
    }
    
    private void Timer() // вывод таймера
    {
        _timer.text = "Time: " + ((int)_time + 1);
    }
}

public enum States // перечисление анимаций
{
    Idle,
    Damagable,
    Dead
}
