using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour 
{
    public Transform amm;
    public GameObject point;
    public int speedAmm = 1500;
	void Update() 
    {
        logic_input();
	}
    public void logic_input() 
    {
        // Создаем клон объекта amm 
        // Клон объекта amm добавляем компонент Rigidbody и после добавляем
        // Силу энергии * на speedAmm
        // Добавляем компонент Light и присваиваем ему true
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            Transform g = (Transform)Instantiate(amm, transform.position, transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(transform.forward * speedAmm);
            point.GetComponent<Light>().enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.G)) 
        {
            point.GetComponent<Light>().enabled = false;
        }
    }
}
