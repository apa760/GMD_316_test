using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class SOItem : ScriptableObject

{

    public string itemName;
    public string itemDescription;
    public int itemValue;
    public Sprite icon;
    public Color color;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
