using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ShowSet 프리팹의 각 숫자들에 들어가는 클래스
public class ShowSetIndex : MonoBehaviour
{
	//화면에 출력될 숫자의 이미지가 들어가있는 Sprite 배열
	[SerializeField]
	private Sprite[]	indexCard;

	//화면에 출력될 숫자를 index로 함
	public void	SetIndex(int index = 0)
	{
		transform.GetComponent<SpriteRenderer>().sprite = indexCard[index];
		return ;
	}
}
