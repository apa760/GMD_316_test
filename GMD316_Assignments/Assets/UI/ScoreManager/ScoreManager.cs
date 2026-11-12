using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private int _points = 0;
    public int currentPoints
    {
        get { return _points; }
        set { 
            //_points = Mathf.Clamp(value, 0, 9999999);
            _points = value;
        }
    }

    public TextMeshProUGUI scoreTextObj;

    public int pointsPerSecond = 10;

    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        StartCoroutine(DistancePoints());
    }

    public void AddPoints(int pointsToAdd)
    {
        currentPoints = currentPoints + pointsToAdd;
        scoreTextObj.text = currentPoints.ToString();
    }

    IEnumerator DistancePoints()
    {
        while (true)
        {
            if(playerStats.isAlive == false)
            {
                yield break;
            }
            AddPoints(pointsPerSecond);
            yield return new WaitForSeconds(1f);
        }
        
    }
}
