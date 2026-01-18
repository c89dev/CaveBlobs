using System;
using System.Collections.Generic;
using Items;
using NUnit.Framework;
using UnityEngine;

namespace Items
{
    public class ChestPoint : MonoBehaviour
    {
        public List<Ore> ChestInventory = new List<Ore>();
        public bool Occupied = false;

        public void PrintInventory()
        {
            if (ChestInventory.Count > 0)
            {
                Debug.Log("Chest contains: " + ChestInventory.Count + "items");
                foreach (Ore o in ChestInventory)
                {
                    Debug.Log(o.OreType);
                }
            }
            else
            {
                Debug.LogWarning("Chest inventory is empty");
                
            }
        }
    }
    
}