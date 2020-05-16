using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour 
{
	public bool Result = false;
	public GameObject Obj;
	// Длина луча
	public int rays = 4;
	// Дистанция поле зрения
	public int distance = 15;
	// Угол обзора
	public float angle = 15;
	// Место расположения лучей
	public Vector3 offset;
	private Transform target;
	void Start() 
	{
		// Найти игровой объект с тэгом Player
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Update()
	{
		// Если дистанция transform.position и 
		if (Vector3.Distance(transform.position, target.position) < distance)
		{
			if (RayToScan())
			{
				// Контакт с целью
				Result = true;
			}
			else
			{
				// Поиск цели...
				Result = false;
			}
		}
	}
	/*bool Ray(Vector3 Direction) 
	{
		bool result = false;
		Vector3 Position = transform.position + offset;	
		RaycastHit RayHit = new RaycastHit();
		if(Physics.Raycast(Position, Direction, out RayHit)) 
		{
			Debug.Log("hit" + RayHit.point);
			GameObject HitObject = RayHit.transform.gameObject;
			ReactiveTarget target = HitObject.GetComponent<ReactiveTarget>();
			if (target != null) 
			{
				result = true;
				Debug.Log("Target Hit"); 
			}
			else 
			{
				StartCoroutine(SphereIndicator(RayHit.point));
			}
		}
		return result;
	}
	private IEnumerator SphereIndicator(Vector3 pos) 
	{
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;
		yield return new WaitForSeconds(1);
		Destroy(sphere);
	}*/
	bool GetRaycast(Vector3 Direction)
	{
		bool result = false;
		RaycastHit RayHit = new RaycastHit();
		Vector3 Position = transform.position + offset;
		if (Physics.Raycast (Position, Direction, out RayHit, distance))
		{
			if (RayHit.transform == target)
			{
				result = true;
				Debug.DrawLine(Position, RayHit.point, Color.red);
			}
			else
			{
				Debug.DrawLine(Position, RayHit.point, Color.blue);
			}
		}
		else
		{
			Debug.DrawRay(Position, Direction * distance, Color.green);
		}
		return result;
	}
	public bool RayToScan() 
	{
		bool result = false;
		bool a = false;
		bool b = false;
		float j = 0;
		for (int i = 0; i < rays; i++)
		{
			var y = Mathf.Sin(j);
			var z = Mathf.Cos(j);
			j += angle * Mathf.Deg2Rad / rays;
			Vector3 Direction = transform.TransformDirection(new Vector3(0, y, z));
			
			a = GetRaycast(Direction);
			if (y != 0) 
			{
				Direction = transform.TransformDirection(new Vector3(0, -y, z));
				b = GetRaycast(Direction);
			}
		}
		result = a || b;
		return result;
	}
}
