using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//화면에 배치된 Card 오브젝트를 섞음
public class CardRollManager : MonoBehaviour
{
	//화면에 배치된 Card 오브젝트들
	[SerializeField]
	GameObject[]		cardObjects;

	//실제 연산에 사용할 Card 오브젝트 속 Card 컴퍼넌트
	[SerializeField]
	private List<Card>	cards = new List<Card>();
	//카드를 섞을 때 사용할 덱. 화면에 배치된 Card가 중첩되지 않게 해줌
	private List<int[]>	cardDeck = new List<int[]>();

	//외부에서 화면에 있는 Card 오브젝트를 참조할 수 있음
	public List<Card>	nineCards { get => cards; }

	//GameObjects로 받아온 Card 오브젝트 속 Card 컴퍼넌트를 따로 저장함
	void	Awake()
	{
		for (int i = 0; i < cardObjects.Length; i++)
			cards.Add(cardObjects[i].GetComponent<Card>());
		return ;
	}

	//카드를 뒤섞음
	public void drawCards()
	{
		int idx;

		resetList();
		for (int i = 0; i < cards.Count; i++)
		{
			idx = Random.Range(0, cardDeck.Count);
			cards[i].HeadType = cardDeck[idx][0];
			cards[i].HeadColor = cardDeck[idx][1];
			cards[i].BodyColor = cardDeck[idx][2];
			cards[i].cardSetting();
			cardDeck.RemoveAt(idx);
		}
		Debug.Log("draw new cards");
		return ;
	}

	//카드덱을 초기화함. 카드덱 속에는 중복된 카드가 없음
	private void resetList()
	{
		cardDeck.Clear();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					cardDeck.Add(new int[] { i, j, k });
				}
			}
		}
		cardDeck.OrderBy(_ => Random.Range(-1.0f, 1.0f)).ToList();
		return ;
	}
}
