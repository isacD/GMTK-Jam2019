﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public GameObject FoodItemPrefab;
    public GameObject DrinkItemPrefab;

    private List<Vector3> _drinkItemSpawns;
    private List<Vector3> _foodItemSpawns;

    // Start is called before the first frame update
    void Start()
    {
        _drinkItemSpawns = GameObject.FindGameObjectsWithTag("DrinkItemSpawn").Select(item => item.transform.position)
            .ToList();
        _foodItemSpawns = GameObject.FindGameObjectsWithTag("FoodItemSpawn").Select(item => item.transform.position)
            .ToList();
        
        SpawnStuff(_foodItemSpawns, FoodItemPrefab);
        SpawnStuff(_drinkItemSpawns, DrinkItemPrefab);
    }
    
    private void SpawnStuff(List<Vector3> spawnPoints, GameObject prefab)
    {
        var totalDrinkItemsToSpawn = (int) Math.Round(spawnPoints.Count() * .1f);
        for (var i = 0; i < totalDrinkItemsToSpawn; i++)
        {
            var randomIndex = Random.Range(0, spawnPoints.Count());
            if (randomIndex >= spawnPoints.Count()) continue;

            var randomSpawn = spawnPoints[randomIndex];
            spawnPoints.RemoveAt(randomIndex);

            Instantiate(prefab, randomSpawn, Quaternion.identity);
        }
    }
}