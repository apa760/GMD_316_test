using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest")]
public class QuestObject : ScriptableObject
{
    
    public string questName;
    public List<string> objectives;
    public int reward;


}
