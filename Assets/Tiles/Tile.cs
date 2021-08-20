using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Tile Settings")]
    [Tooltip("Tower that will be spawned on this specific tile")]
    [SerializeField] Tower towerPrefab; //Note: Changing this at runtime will allow for different towers to be placed. GUI may be used to acheive that.
    [Tooltip("Can the player place a tower on this tile?")]
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get { return isPlaceable; } }

    GridManager gridManager;
    PathFinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<PathFinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!IsPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceievers();
            }
        }
    }
}
 