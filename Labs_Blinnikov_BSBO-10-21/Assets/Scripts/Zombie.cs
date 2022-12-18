using Unity.VisualScripting;
using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] private float damagePeriod; // период между ударами
    private float _timer; // таймер
    [SerializeField] private Sprite zombieSprite; // спрайт
    [SerializeField] private float attackDistance; // дистанция атаки
    private float _distance; // дистанция
    
    private void Awake() // инициализация полей
    {
        Health = 50;
        if (Speed == 0)
        {
            Speed = 100;
        }
        if (Damage == 0)
        {
            Damage = 20;
        }
        if (Radius == 0)
        {
            Radius = 5f;
        }
        if (damagePeriod == 0)
        {
            damagePeriod = 3f;
        }
        if (attackDistance == 0)
        {
            attackDistance = 0.6f;
        }
        _timer = damagePeriod;
        if (Target == null)
        {
            Target = GameObject.Find("Player").GetComponent<Entity>();
        }
        if (zombieSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = zombieSprite;
        }
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack() // атака
    {
        _timer += Time.deltaTime;
        _distance = Vector2.Distance(transform.position, Target.transform.position);
        if (_distance <= Radius)
        {
            Move(Target.transform);
            Hit();
        }
        else
        {
            Rb.velocity = new Vector2(0, 0);
        }
    }

    void Hit() // удар
    {
        if (_distance <= attackDistance && _timer >= damagePeriod)
        {
            Target.Damagable(Damage);
            _timer = 0f;
        }
    }
}
