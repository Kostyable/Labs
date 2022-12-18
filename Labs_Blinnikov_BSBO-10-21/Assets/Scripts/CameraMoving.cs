using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Transform _player;
    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }
    
    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = _player.position.x;
        temp.y = _player.position.y;
        transform.position = temp;
    }
}
