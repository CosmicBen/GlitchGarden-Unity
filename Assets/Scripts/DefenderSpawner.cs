using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defenderPrefab;
    private GameObject defenderParent;
    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void OnMouseDown()
    {
        if (defenderPrefab != null)
        {
            AttemptToPlaceDefender(GetSquareClicked());
        }
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 position)
    {
        float snappedX = Mathf.RoundToInt(position.x);
        float snappedY = Mathf.RoundToInt(position.y);
        return new Vector2(snappedX, snappedY);
    }

    private void SpawnDefender(Vector2 gridPosition)
    {
        Defender defender = Instantiate(defenderPrefab, gridPosition, Quaternion.identity);
        defender.transform.SetParent(defenderParent.transform);
    }

    private void AttemptToPlaceDefender(Vector2 gridPosition)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();

        if (starDisplay != null && starDisplay.HaveEnoughStars(defenderCost))
        {
            starDisplay.SpendStars(defenderCost);
            SpawnDefender(gridPosition);
        }
    }

    public void SetSelectedDefender(Defender defender)
    {
        defenderPrefab = defender;
    }
}
