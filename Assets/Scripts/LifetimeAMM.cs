using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeAMM : MonoBehaviour 
{
	public float Wait_Time;
	public bool Wall;
	public bool Enemy;
	public bool Player;	
	void Start () 
	{

	}
	void Update () 
	{
		if (Wall || Enemy || Player)
		{
			Destroy(this.gameObject);
		}
		else 
		{
			if (Wait_Time < 1)
			{
				Wait_Time += Time.deltaTime;
			}
			else 
			{
				Destroy(this.gameObject);
			}
		}
	}
	public void OnCollisionEnter(Collision Col)
    {
		if (Col.gameObject.tag == ("Untagged") && Wall == false || 
		    Col.gameObject.tag == ("Enemy") && Enemy == false || 
		    Col.gameObject.tag == ("Player") && Player == false) 
		{
			Wall = true;
            Enemy = true;
			Player = true;
			print("oof");
		}
    }
}
