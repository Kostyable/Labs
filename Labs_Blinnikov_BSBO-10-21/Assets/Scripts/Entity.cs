using UnityEngine;

public abstract class Entity : MonoBehaviour // класс сущностей
{
    [SerializeField] private int speed; //скорость
    protected int Speed
    {
        get => speed;
        set => speed = value;
    }
    
    private Rigidbody2D _rb; // компонент Rigidbody 2D
    protected Rigidbody2D Rb
    {
        get => _rb;
        set => _rb = value;
    }
    
    private Vector2 _moveDir; // направление движения
    protected Vector2 MoveDir
    {
        get => _moveDir;
        set => _moveDir = value;
    }

    protected void Move(Transform target) // движение к цели
    {
        MoveDir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(MoveDir.y, MoveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rb.velocity = MoveDir * Speed * Time.fixedDeltaTime;
    }

    public virtual void Damagable(int enemyDamage) // получение урона
    {
        
    }
}
