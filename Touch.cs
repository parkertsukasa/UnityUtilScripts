using UnityEngine;
using System.Collections;


//Swipe.Swipe()をアップデートで呼び出す
public class Touch : MonoBehaviour
{
	public float swipe_sensitivity = 10;

	public bool landscape = false;

	private Vector3 startpos;
	private Vector3 endpos;

	public string Swipe()
	{
		string direction = "no_swipe";

		if(Input.GetMouseButtonDown(0))
			startpos = Input.mousePosition;
		
		if(Input.GetMouseButtonUp(0))
		{
			endpos = Input.mousePosition;

			direction = GetDirection ();
		}
			
			return direction;
	}

	string GetDirection()
	{
		string s = "no_swipe";

		float diffx = endpos.x - startpos.x;
		float diffy = endpos.y - startpos.y;

		//Debug.Log (diffx + ":" + diffy);

		if (Mathf.Abs(diffx) > Mathf.Abs(diffy)) {
			if (diffx > swipe_sensitivity)
				s = landscape ? "up" : "right";
			if (diffx < -swipe_sensitivity)
				s = landscape ? "down" : "left";
		}
		else if (Mathf.Abs(diffx) < Mathf.Abs(diffy))
		{
			if (diffy > swipe_sensitivity)
				s = landscape ? "right" : "up";
			if (diffy < -swipe_sensitivity)
				s = landscape ? "left " : "down";
		}
		else
		{
			s = "tap";
		}

		return s;

	}



}

