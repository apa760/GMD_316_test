using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    public int currentHealth
    {
        get { return _health; }
        set { 
            _health = Mathf.Clamp(value, 0, 5);
            _health = value;
            if (_health <= 0)
            {
                isAlive = false;
            }
        }
    }
    [SerializeField] private int _moveSpeed = 5;
    public int currentMoveSpeed
    {
        get { return _moveSpeed; }
        set { 
            _moveSpeed = Mathf.Clamp(value, 0, 100);
            _moveSpeed = value;
        }
    }
    [SerializeField] private int _mechParts = 0;
    public int currentMechParts
    {
        get { return _mechParts; }
        set {
            _mechParts = Mathf.Clamp(value, 0, 999);
            _mechParts = value; 
        }
    }

    public bool isAlive = true;

}
