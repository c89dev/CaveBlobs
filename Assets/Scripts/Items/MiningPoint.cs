using System;
using System.Collections.Generic;
using Items;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class MiningPoint : MonoBehaviour
{
    private List<Ore> _oreList = new List<Ore>
    {
        new Ore("Gold", 500),
        new Ore("Silver", 100),
        new Coal("Coal", 75, 50),
        new Ore("Granit", 5),
        new Ore("Dirt", 0),
    };

    public List<Ore> MineableOres;
    public bool Occupied = false;
    public int oreCount;


    void Start()
    {
        MineableOres = new List<Ore>();
        GenerateContent();
        oreCount  = MineableOres.Count;
    }

    private void GenerateContent()
    {
        for (int i = 0; i < 40; i++)
        {
            var randOre = _oreList[Random.Range(0, _oreList.Count)];
            MineableOres.Add(randOre);
        }

        // foreach (var ore in mineableores)
        // {
        //     debug.log(ore.oretype);
        // }
    }



// Update is called once per frame
    void Update()
    {
    }
}