using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSeleter : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
			if (hit.collider != null && hit.transform.gameObject.CompareTag("Card"))
			{
				Debug.Log(hit.transform.gameObject.name);
			}
		}
		return ;
	}
}
