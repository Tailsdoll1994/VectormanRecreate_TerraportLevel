using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Script : MonoBehaviour
{
    // Таймер
    public float Wait_Time;
    public bool Death;
    // Стартовая позиция персонажа на уровне
    public GameObject player_model;
    public Vectorman vectorman;
    public Player_GUI PG;
    void Update()
    {
        if (Death_Timer() || Death_Abyss() || Death_Health()) 
        {
            Wait_Time += Time.deltaTime;
            if (Wait_Time > 5) 
            {
                SceneManager.LoadScene("GameTest");
                Wait_Time = 0;
            }
        }
    }
    // Смерть от падения в пропасть 
    bool Death_Abyss() 
    {
        // Если позиция по Vector.Y меньше -5
        // Персонаж перемещается на стартовую позицию (StartPos)
        if (transform.position.y < -5 && Death == false)
        {
            Death = true;
            Destroy(this.player_model);
        }
        return Death;
    }
    // Cмерть NPC при окончании жизней
    bool Death_Health() 
    {
        if (vectorman.Life == 0 && this.player_model.activeSelf && Death == false) 
		{
            Death = true;
			Destroy(this.player_model);
		}
        return Death;
    }
    bool Death_Timer() 
    {
        if (PG.ScoreText.text == "00:00" && Death == false) 
        {
            Death = true;
            Destroy(this.player_model);
        }
        return Death;
    }
}
