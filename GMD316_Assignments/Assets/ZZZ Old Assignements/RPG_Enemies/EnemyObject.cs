using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public int health;
    public int attackPower;
    public float moveSpeed;
    public enum WEAKNESS
    {
        FIRE,
        WATER,
        ICE,
        EARTH
    };
    public WEAKNESS weakness;
}
