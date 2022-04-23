using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds.")]
    [SerializeField] private float levelTime = 60.0f;
    private Slider timeSlider;
    private bool triggeredLevelFinished = false;

    private void Awake()
    {
        timeSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (!triggeredLevelFinished)
        {
            timeSlider.value = Mathf.Clamp01(Time.timeSinceLevelLoad / levelTime);

            bool timerFinished = Time.timeSinceLevelLoad >= levelTime;

            if (timerFinished)
            {
                FindObjectOfType<LevelController>().LevelTimerFinished();
                triggeredLevelFinished = true;
            }
        }
    }
}
