using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsObject : ScriptableObject
{
    public UnityEvent LEVELUP;


    [SerializeField] private int _health = 5;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
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


    public List<InventorySlot> playerInventory;



}
