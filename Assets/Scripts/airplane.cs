using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplane : MonoBehaviour 
{
    // Создаём несколько окон для ручного ввода значения
    public float X, Y, Z;

    void Start ()
    {
        
    }
	
	void Update ()
    {
        // Перемещение объекта по оси X, Y, Z по множеное на время 
        transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}
