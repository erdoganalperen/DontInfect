using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI TimeText;
    private void Start()
    {
        HealthText.text = PlayerManager.Instance.Health.ToString();
    }
    private void Update()
    {
        UpdateTimeText();
    }
    private void OnEnable()
    {
        PlayerTriggerController.onTriggerCollision += UpdateHealthTextUI;
    }
    void UpdateHealthTextUI(AbstractTrigger abstractTrigger)
    {
        HealthText.text = PlayerManager.Instance.Health.ToString();
    }

    void UpdateTimeText()
    {
        TimeText.text = string.Format("{0:0.00}", Time.timeSinceLevelLoad);
    }
}
