using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    EnemyController Enemy;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Enemy = FindObjectOfType<EnemyController>();
    }

    private void Update()
    {
        CurrentHealth = Enemy.maxHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
