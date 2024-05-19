using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSetIndex : MonoBehaviour
{
	[SerializeField]
	private Sprite[]	indexCard;

	public void	SetIndex(int index = 0)
	{
		transform.GetComponent<SpriteRenderer>().sprite = indexCard[index];
		return ;
	}
}
