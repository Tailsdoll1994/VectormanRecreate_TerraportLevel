using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_GUI : MonoBehaviour 
{
	public Text ScoreText;
	private string Min;
	private int Sec;
	public int Timer;
	private float Wait_Time;
	public Image[] Lives;
	public Sprite Full;
	public Sprite Empty;
	[SerializeField] private Vectorman player;
	void Start()
	{
		Timer = 300;
		InvokeRepeating("UpdateTimer", 1, 1);
	}
	void Update() 
	{
		BackMenu();
		LogicHealth();
	}
	// Обновление таймера
	public void UpdateTimer() 
	{
		Timer -= 1;
		
		if (Timer > 0) 
		{
			// Для расчета минуты используется Ceil (Возвращает наименьшее целое число, большее или равное) и приводим его к стандарту таймера
			// Для расчета секунду достаточно использовать % для выявления остатка от изначального числа
			// Выводим минуту и секунду в gui text и так же приводим секунду к стандарту таймера
			Min = Mathf.Ceil(Timer / 60).ToString("00");
			Sec = Timer % 60;
			ScoreText.text = Min + ":" + Sec.ToString("00");
		}
		else 
		{
			ScoreText.text = "00:00";
		}
		
	}
	// Логика жизней персонажа
	public void LogicHealth() 
	{
		for (int i = 0; i < Lives.Length; i++) 
		{
			if (i < player.Life)
			{
				Lives[i].sprite = Full;
			}
			else
			{
				Lives[i].sprite = Empty;
			}
		}
	}
	private void BackMenu () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			SceneManager.LoadScene("LevelMenu");
		}
	}
}
	