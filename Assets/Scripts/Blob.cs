using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Blob : MonoBehaviour
{
    public bool isMoving = false;
    public bool hasLoot = false;
    public int Energy = 75;
    public List<Ore> BlobInventory = new List<Ore>(1);

    public float speed = 1.0f;

    public Transform caveTarget;
    public Transform chestTarget;
    public Transform idleTarget;
    public Transform restTarget;
    private Transform _currentTarget;


    private void Mine(MiningPoint miningPoint)
    {
        if (miningPoint.MineableOres.Count > 0)
        {
            var ore = miningPoint.MineableOres[0];
            if (BlobInventory.Count < 1)
            {
                Debug.Log("Digging...");
                BlobInventory.Add(ore);
                miningPoint.MineableOres.RemoveAt(0);
                Energy -= 10;
            }

            foreach (var item in BlobInventory)
            {
                Debug.Log($"BLOB CARRIES: {item.OreType}");
            }

            if (BlobInventory.Count >= 1)
            {
                _currentTarget = chestTarget;
                speed = 9f;
            }
        }
        else
        {
            Debug.Log("The mine i was in has depleted");
            _currentTarget = idleTarget;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiningPoint"))
        {
            Debug.Log("Reached mining point");
            var cmp = other.GetComponent<MiningPoint>();
            if (!cmp.Occupied)
            {
                cmp.Occupied = true;
                if (cmp != null)
                {
                    Mine(cmp);
                }
            }
        }
        else if (other.CompareTag("ChestPoint"))
        {
            var cmp = other.GetComponent<ChestPoint>();
            if (!cmp.Occupied)
            {
                cmp.Occupied = true;
                if (cmp != null)
                {
                    Debug.Log("Reached chest point");
                    if (BlobInventory.Count > 0)
                    {
                        cmp.ChestInventory.Add(BlobInventory[0]);
                        Debug.Log($"BLOB DEPOSITED: {BlobInventory[0].OreType}");
                        BlobInventory.RemoveAt(0);
                        _currentTarget = caveTarget;
                    }
                }

                if (Energy < 10)
                {
                    Debug.Log("I'm starving");
                    _currentTarget = restTarget;
                }
            }
        }
        else if (other.CompareTag("RestPoint"))
        {
            var cmp = other.GetComponent<RestPoint>();
            if (!cmp.Occupied)
            {
                cmp.Occupied = true;
                if (cmp != null && cmp.Food > 150)
                {
                    cmp.Food -= 150;
                    Energy += 25;
                    _currentTarget = caveTarget;
                }
                else
                {
                    Debug.Log("There is no more food left...");
                    _currentTarget = idleTarget;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MiningPoint"))
        {
            var cmp = other.GetComponent<MiningPoint>();
            cmp.Occupied = false;
        }
        else if (other.CompareTag("ChestPoint"))
        {
            var cmp = other.GetComponent<ChestPoint>();
            cmp.Occupied = false;
        }
        else if (other.CompareTag("RestPoint"))
        {
            var cmp = other.GetComponent<RestPoint>();
            cmp.Occupied = false;
        }
    }

    void DoWork()
    {
        transform.LookAt(_currentTarget, worldUp: Vector3.up);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, step);

        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.001f)
        {
            speed = 0.0f;
        }
    }

    void Awake()
    {
        _currentTarget = caveTarget;
    }

    // Update is called once per frame
    void Update()
    {
        DoWork();
    }
}