using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager main;

    [Header("Stats")]
    [SerializeField] private TowerS[] towers;
    
    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public TowerS GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }



}
