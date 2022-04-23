using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int baseLives = 3;
    [SerializeField] private int damage = 1;
    private int lives = 0;

    private TextMeshProUGUI livesText = null;

    private void Awake()
    {
        lives = Mathf.RoundToInt(baseLives - PlayerPrefsController.GetDifficulty());

        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
