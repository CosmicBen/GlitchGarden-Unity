using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();

        if (costText != null)
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
        else
        {
            Debug.LogError(name + " has no cost text, add some!");
        }
    }

    private void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponentInChildren<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponentInChildren<SpriteRenderer>().color = Color.white;

        DefenderSpawner spawner = FindObjectOfType<DefenderSpawner>();

        if (spawner != null)
        {
            spawner.SetSelectedDefender(defenderPrefab);
        }
    }
}
