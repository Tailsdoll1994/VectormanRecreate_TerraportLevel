using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SegaLogo : MonoBehaviour
{
    public float Wait_Time;
    void Update()
    {
        if (Wait_Time < 5) 
        {
            Wait_Time += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("LevelMenu");
        }
    }
}
