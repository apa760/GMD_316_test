using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI levelStatText;
    public TextMeshProUGUI healthStatText;
    public TextMeshProUGUI manaStatText;
    public TextMeshProUGUI attackPowerStatText;
    public TextMeshProUGUI speedStatText;





    public void SetStatText(PlayerStatsObject playerStats)
    {
        levelStatText.text = $"Level: {playerStats.Level}";
        healthStatText.text = $"Health: {playerStats.Health}";
        manaStatText.text = $"Mana: {playerStats.Mana}";
        attackPowerStatText.text = $"Attack: {playerStats.AttackPower}";
        speedStatText.text = $"Speed: {playerStats.Speed}";
    }
}
