using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomItem : MonoBehaviour
{
    public GameObject[] dropItems;

    void Update()
    {
        SpawnItem();

    }

    public void SpawnItem()
    {
       int item = Random.Range(0, dropItems.Length);
       Instantiate(dropItems[item]);

    }
 }
