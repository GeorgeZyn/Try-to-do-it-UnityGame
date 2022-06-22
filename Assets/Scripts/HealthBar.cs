using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   private float maxHP = 100f;
   public float currentHealth;
   private Image healthBar;
   Player player;

   private void Start()
   {
      healthBar = GetComponent<Image>();
      player = FindObjectOfType<Player>();
   }

   private void FixedUpdate()
   {
      currentHealth = player.myHealth;
      healthBar.fillAmount = currentHealth / maxHP;
      if (currentHealth == 0) healthBar.fillAmount = 0.05f;
   }
}
