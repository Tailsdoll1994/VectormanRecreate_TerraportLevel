using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC_Motor : MonoBehaviour
{
    private float Move_Horizontal;
    private float Wait_Time;
    private float Start_Wait_time;
    public float speed;
    public int NPCLife = 5;
    public Transform Player_Attack;
    public Transform A;
    public Transform B;
    private Transform To_Move;
    [SerializeField] private Rigidbody RB;
    private float step;
    [SerializeField] private GUN_NPC Gun;
    Vector3 Start_Positoin;
    
    private void Start()
    {
        To_Move = A;
        Wait_Time = Start_Wait_time;
        Start_Positoin = transform.position;
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Метод описывающий смерть персонажа в пропости
        DeadZone_Abyss();
        // Метод описывающий смерть NPC при окончании жизней
        Death_HealthNPC();
    }
    private void FixedUpdate()
    {
        if (A || B) 
        {
            EnemyMovement();
        }
    }
    // Логика передвижения NPC по локации 
    void EnemyMovement() 
    {
        float step = speed * 10 * Time.fixedDeltaTime;
        if (Mathf.Abs(To_Move.position.x - transform.position.x) < 1)
        {
            if (Vector3.Equals(To_Move.position, A.position))
            {
                To_Move = B;
            }
            else 
            {
                To_Move = A;
            }
        }
        Vector3 NewPosition = Vector3.MoveTowards(transform.position, new Vector2(To_Move.position.x, 0.0f), step);
        Move_Horizontal = NewPosition.x - transform.position.x;
        transform.position = NewPosition;
        // Объявляем переменую для возможности поворота модели персонажа
        Vector3 movement = new Vector3(Move_Horizontal, 0.0f, 0.0f);
		if (movement != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(movement);
		}
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Amm") && NPCLife > 0)
        {
            NPCLife -= 1;
        }
    }
    // смерть NPC
    public void Death_HealthNPC()
	{
		if (NPCLife == 0 && this.gameObject.activeSelf) 
		{
			this.gameObject.SetActive(false);
		}
	}
    void DeadZone_Abyss() 
    {
        // Если позиция по Vector.Y меньше -5
        // Персонаж перемещается на стартовую позицию (startPos)
        if (transform.position.y < -5)
        {
            transform.position = Start_Positoin;
            // Обнуляем скорость персонажа при респавне
            RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}