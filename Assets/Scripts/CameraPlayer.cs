using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    // Расположение игрока
    public Transform Player;
    // Скорость камеры
    public float speed = 1.25f;
    // Плавность истина
    private bool smooth = true;
    // Скорость плавности 
    public float SmoothSpeed = 3.75f;
    // Таймер
    public float Wait_Time;
    // Смещение
    public Vector3 offset = new Vector3(5, 2, -25);
    // Дальность по Y
    public Vector3 rangeY = new Vector3(0, 10, 0);
    // Дальность по X
    public Vector3 rangeX = new Vector3(5, 0, 0);
    // Определение куда смотрит персонаж (-1 = влево, 1 = вправо)
    public float LastAxis = 1.0f;
    private Vector3 zero = Vector3.zero;
    void LateUpdate()
    {
        Camera_Input();
    }
    public void Camera_Input() 
    {
        // При соблюдении условия переменой axis и.
        // При соблюдении условия задержки и нажатии W или S.
        // Первое, запускается секундомер.
        // Второе, производится смещение камеры (rangeY) по Y на 10\-10 с сохранением rangeX.
        // Если axis не истина то.
        // Первое, передаем значение axis в LastAxis.
        // Второе, запускаем секундомер.
        // Третье, производится смещение камеры (rangeX) по X на 5\-5.
        float axis = Input.GetAxisRaw("Horizontal");
        if (axis == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {

                if (Wait_Time < 0.2)
                {
                    Wait_Time += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + offset + rangeY + rangeX * LastAxis, ref zero, SmoothSpeed);
                }
                return;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Wait_Time < 0.2)
                {
                    Wait_Time += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + offset - rangeY + rangeX * LastAxis, ref zero, SmoothSpeed);
                }
                return;
            }  
        }
        else
        {
            LastAxis = axis;
            if (Wait_Time < 0.1)
            {
                Wait_Time += Time.deltaTime;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position + offset + rangeX * LastAxis, speed * Time.fixedDeltaTime);
            }
            return;
        }
        // Если персонаж стоит на месте
        // Запускается условия когда камера следует за игровым персонажем и обнуляем секундомер
        Wait_Time = 0;
        Vector3 DesiredPosition = Player.transform.position + offset + rangeX * LastAxis;
        if (smooth)
        {
            transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref zero, SmoothSpeed);
        }
        else
        {
            transform.position = DesiredPosition * Time.fixedDeltaTime;
        }
    }
}