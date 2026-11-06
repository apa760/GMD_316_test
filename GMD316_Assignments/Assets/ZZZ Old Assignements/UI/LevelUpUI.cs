using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public StatsUI statsUI;

    public void OnLevelUpUI(PlayerStatsObject playerStats)
    {
        gameObject.SetActive(true);
        statsUI.SetStatText(playerStats);
    }


}
