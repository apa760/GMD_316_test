using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character")]
public class CharacterObject : ScriptableObject
{
    
    public string characterName;
    public int health;
    public float moveSpeed;
    public List<string> skills;


}
