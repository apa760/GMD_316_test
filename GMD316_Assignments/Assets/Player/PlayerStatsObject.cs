using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsObject : ScriptableObject
{
    public UnityEvent LEVELUP;

    [SerializeField] private int _maxResourceStatValue = 100;
    [SerializeField] private int _maxSubStatValue = 999;

    [SerializeField] private int _health = 5;
    public int Health
    {
        get { return _health; }
        set { 
            _health = Mathf.Clamp(value, 0, _maxResourceStatValue);
            _health = value;
        }
    }
    [SerializeField] private int _mana = 5;
    public int Mana
    {
        get { return _mana; }
        set { 
            _mana = Mathf.Clamp(value, 0, _maxResourceStatValue);
            _mana = value;
        }
    }
    [SerializeField] private int _speed = 5;
    public int Speed
    {
        get { return _speed; }
        set { 
            _speed = Mathf.Clamp(value, 0, _maxSubStatValue);
            _speed = value;
        }
    }
    [SerializeField] private int _attackPower = 5;
    public int AttackPower
    {
        get { return _attackPower; }
        set {
            _attackPower = Mathf.Clamp(value, 0, _maxSubStatValue); 
            _attackPower = value; 
        }
    }

    [SerializeField] private int _expPoints = 0;
    public int ExpPoints
    {
        get { return _expPoints; }
        set {
            _expPoints = Mathf.Clamp(value, 0, 100);
            if(_expPoints >= 100)
            {
                LEVELUP.Invoke();
                StatPoints += 1;
                _expPoints = 0;
                return;
            }
            _expPoints = value; 
        }
    }
    [SerializeField] private int _level = 1;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
     [SerializeField] private int _statPoints = 0;
    public int StatPoints
    {
        get { return _statPoints; }
        set { _statPoints = value; }
    }


    public List<InventorySlot> playerInventory;



}
