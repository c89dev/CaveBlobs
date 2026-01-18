using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Ore 
{
    public string OreType {get; set;}
    public int OreValue {get; set;}
    
    public Ore(string oreType, int oreValue)
    {
        OreType = oreType;
        OreValue = oreValue;
    }

    public Ore()
    {
        
    }
}
