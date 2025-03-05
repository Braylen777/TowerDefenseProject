using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager main;

    [Header("Stats")]
    [SerializeField] private GameObject[] TowerPrefabs;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return TowerPrefabs[selectedTower];
    }


}
