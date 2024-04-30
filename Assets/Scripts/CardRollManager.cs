using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRollManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] cards;

	List<int[]> list = new List<int[]>(); 
	// Start is called before the first frame update
	void Start()
	{
		drawCards();
		return ;
	}

	public void drawCards()
	{
		int idx;

		resetList();
		for (int i = 0; i < cards.Length; i++)
		{
			idx = Random.Range(0, list.Count);
            cards[i].GetComponent<Card>().HeadType = list[idx][0];
            cards[i].GetComponent<Card>().HeadColor = list[idx][1];
			cards[i].GetComponent<Card>().BodyColor = list[idx][2];
			cards[i].GetComponent<Card>().cardSetting();
			list.RemoveAt(idx);
		}
		return ;
	}

	void resetList()
	{
		list.Clear();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					list.Add(new int[] { i, j, k });
				}
			}
		}
		list.OrderBy(_ => Random.Range(-1.0f, 1.0f)).ToList();
		return ;
	}
}
