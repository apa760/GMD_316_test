using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Player", order = 2)]
public class PlayerSaveData : ScriptableObject
{
    [SerializeField] string playerName;
    [SerializeField] string lastPlayedTime;



}