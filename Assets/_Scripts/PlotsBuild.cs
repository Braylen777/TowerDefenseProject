using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotsBuild : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public AudioClip buildSound;
    private GameObject tower;
    private Color startColor;
    private Vector3 point;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        AudioSource.PlayClipAtPoint(buildSound, point);
        TowerS towerToBuild = BuildingManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        //Debug.Log("Tower Built");
    }



}
