using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int treasureCount;
    public TextMeshProUGUI displayCount;
    private Treasure treasure;
    [SerializeField] GameObject treasureGO;

    private void Awake()
    {
        //treasure = character.GetComponent<Treasure>();
        treasureCount = 0;
        DisplayTreasure(treasureCount);
    }

    private void OnEnable()
    {
        treasureGO = GameObject.FindGameObjectWithTag("Treasure");
        Debug.Log("Found " + treasureGO);
        treasure = treasureGO.GetComponent<Treasure>();
        treasure.CharacterTreasureCount += DisplayTreasure;
    }

    private void OnDisable()
    {
        treasure.CharacterTreasureCount -= DisplayTreasure;
    }

    private void SetTreasureObject(GameObject thisTreasure)
    {
        Debug.Log("Set Treasure Object");
        treasure = thisTreasure.GetComponent<Treasure>();
    }

    public void DisplayTreasure(int i)
    {
        Debug.Log(treasureCount);
        treasureCount += i;
        displayCount.text = treasureCount.ToString();
    }
}
