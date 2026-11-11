using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyObject enemyData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemyData != null)
        {
            Debug.Log(enemyData.enemyName + ":");
            Debug.Log("Health: " + enemyData.health.ToString());
            Debug.Log("Weakness: " + enemyData.weakness);
            Debug.Log("___________________________________________________________________");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
