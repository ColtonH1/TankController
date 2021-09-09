using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int treasureCount;
    public TextMeshProUGUI displayCount;

    // Start is called before the first frame update
    void Start()
    {
        treasureCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTreasure();
    }

    private void DisplayTreasure()
    {
        displayCount.text = treasureCount.ToString();
    }
}
