using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GUN_NPC : MonoBehaviour 
{
    public float Wait_Time;
    public Transform amm;
    public GameObject point;
    [SerializeField] private Vision Gunshot;
    public int speedAmm = 1500;
	void Update()
    {
        if (Gunshot.Result)
        {
            if (Wait_Time < 5) 
            {
                Wait_Time += Time.deltaTime;
            }
            else if (Wait_Time > 5) 
            {
                shot(1);
                point.GetComponent<Light>().enabled = false;
                Wait_Time = 0;
            }
        }
	}
    public void shot(int numfor) 
    {
        // Создаем клон объекта amm 
        // Клон объекта amm добавляем компонент Rigidbody и после добавляем
        // Силу энергии * на speedAmm
        // Добавляем компонент Light и присваиваем ему true
        for (int i = 0; i < numfor; i++) 
        {
            Transform g = (Transform)Instantiate(amm, transform.position, transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(transform.forward * speedAmm);
            point.GetComponent<Light>().enabled = true;
        }
    }
}
