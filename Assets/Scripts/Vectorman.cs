using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vectorman : MonoBehaviour
{
    // Скорость движение персонажа
    public float Speed = 5.0f;
    // Сила прыжка
    public int JumpForce;
    // Таймер
    public float Wait_Time;
    // Двигаться по горизонтали
    public float MoveHorizontal;
    // Определение поверхности для прыжка 
    public bool IsGround;
    // Двойной прыжок
    public bool DoubleJump;
    // Контроль положения объекта с помощью физического моделирования
    [SerializeField] private Rigidbody rb;
    // Стартовая позиция персонажа на уровне
    [SerializeField] private Vector3 StartPos;
    // Количество жизней
    public int Life = 4;
    void Start()
    {
        // Присваиваем значение StartPos
        StartPos = transform.position;
        // Присваиваем значение rb
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Перемещение персонажа по горизонтали 
        // ForceMode (Применить силу) в момент нажатия направления используя 
        // Impulse (Мгновенный импульс силы который задействует массу персонажа указаного в Rigidbody)
        Vector3 V3M = new Vector3(MoveHorizontal, 0.0f, 0.0f);
        rb.AddForce(V3M * Speed, ForceMode.Impulse);
    }
    void FixedUpdate()
    {
        // Метод прыжка 
        Jump();
        // Метод управление персонажа
        Input_Control();
        // Метод ускорение персонажа
        Acceleration();
    }
    // Контроль управления
    public void Input_Control() 
    {
        // Присваиваем значения виртуальной оси по которой может передвигатся персонаж 
        // Выставляем скорость передвижение персонажа
        // Объявляем переменую для возможности поворота модели персонажа
        MoveHorizontal = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector3(MoveHorizontal * Speed * Time.deltaTime, rb.velocity.y, 0.0f);
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, 0.0f);
		if (movement != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(movement);
		}
    }
    // Ускорение персонажа
    void Acceleration() 
    {
        // Если все ниже условия соблюдены то,
        // Первое, запускаем секундомер
        // Второе, даём ускорение игровому объекту посредством метода Vector3.MoveTowards и умножения (MoveHorizontal * 4) * Time.fixedDeltaTime
        // Третье, если персонаж перестает двигаться или начал прыгать секундомер обнуляется 
        if (MoveHorizontal != 0)
        {
            if (MoveHorizontal == 1)
            {
                if (Wait_Time < 0.5) 
                {
                    Wait_Time += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(MoveHorizontal, 0.0f), (MoveHorizontal * 4) * Time.fixedDeltaTime);
                }
            }
            else if (MoveHorizontal == -1)
            {
                if (Wait_Time < 0.5)
                {
                    Wait_Time += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(MoveHorizontal, 0.0f), (MoveHorizontal * 4) * Time.fixedDeltaTime);
                }
            }
            else
            {
                Wait_Time = 0; 
            }
        }
        else 
        {
            Wait_Time = 0;
        }
    }
    // Распознование поверхности/объектов
    void OnCollisionEnter(Collision collision)
    {
        // Если тэг объекта равен Untagged и IsGround false
        // То персонаж может использовать двойной прыжок
        if (collision.gameObject.tag == ("IsGround") && IsGround == false)
        {
            IsGround = true;
            DoubleJump = true;
        }
        if (collision.gameObject.tag == "Amm" && Life > 0)
        {
            Life -= 1;
            print(Life);
        }
    }
    // Прыжок персонажа
    private void Jump()
    {
        // Если значение Input.GetKeyDown true при нажатии
        // Space и оно IsGround производится двойной прыжок 
        if (Input.GetKeyDown(KeyCode.Space) && (IsGround || DoubleJump))
        {
            // Если IsGround false прыжок не производится
            // Указываем силу прыжка
            // ForceMode (Применить силу) в момент нажатия space используя 
            // Impulse (Мгновенный импульс силы который задействует массу персонажа указаного в Rigidbody)
			if (!IsGround)
			{
				DoubleJump = false;
			}
            rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            IsGround = false;
        }
    }
}