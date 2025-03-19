
using System;
using UnityEngine;

[Serializable]
public class TowerS
{
    public string name;
    public GameObject prefab;

    public TowerS (string _name, GameObject _prefab)
    {
        name = _name;
        prefab = _prefab;
    }


}
