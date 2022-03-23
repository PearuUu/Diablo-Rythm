using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	#region Variables

	public Slider slider;

	#endregion

	#region User Methods
	
	public void SetMaxHealth(float maxHealth)
	{
		slider.maxValue = maxHealth;
		slider.value = maxHealth;
	}

	public void SetHealt(float health)
	{
		slider.value = health;
	}

	#endregion
	
}
