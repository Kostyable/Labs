using UnityEngine;

public class Chip : Enemy
{
    [SerializeField] private Sprite chipSprite; // спрайт
    private float _timer; // таймер
    private float _distance; // дистанция
    private bool _isTrigger;
    void Awake() // инициализация полей
    {
        Health = 20;
        if (Speed == 0)
        {
            Speed = 125;
        }
        if (Damage == 0)
        {
            Damage = 50;
        }
        if (Radius == 0)
        {
            Radius = 2f;
        }
        if (Target == null)
        {
            Target = GameObject.Find("Player").GetComponent<Player>();
        }
        if (chipSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = chipSprite;
        }
        Rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Attack();
    }

    void Attack() // атака
    {
        _distance = Vector2.Distance(transform.position, Target.transform.position);
        if (_distance <= Radius || _isTrigger)
        {
            Trigger();
            _isTrigger = true;
        }
    }
    
    void Trigger() // срабатывание
    {
        Move(Target.transform);
        _timer += Time.deltaTime;
        if (_timer >= 3f)
        {
            Explode();
        }
    }

    void Explode() // взрыв
    {
        if (_distance <= 1f)
        {
            Target.Damagable(Damage);
        }
        Destroy(gameObject);
    }
}