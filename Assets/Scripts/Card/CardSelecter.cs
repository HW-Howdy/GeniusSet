using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


//화면에 보이는 Card를 클릭할 떄의 이벤트를 관조함
public class CardSeleter : MonoBehaviour
{
	//선택된 Card 오브젝트의 Card 컴포넌트 리스트
	private List<Card>				seletedCards = new List<Card>();

	//선택된 Card의 연산을 해줄 클래스
	private SetChecker				setChecker;
	//합의 결과를 출력해주는 클래스
	private PrintEventPanelManager	printEventPanelManager;

	private void Start()
	{
		setChecker = transform.GetComponent<SetChecker>();
		printEventPanelManager = GameObject.Find("CanvasUI").GetComponent<PrintEventPanelManager>();
		return ;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
			if (hit.collider != null && hit.transform.gameObject.CompareTag("Card"))
			{
				Debug.Log("Hit card : " + hit.transform.gameObject.name);
				ClickCard(hit.transform.gameObject.GetComponent<Card>());
			}
		}
		return ;
	}

	/*  
	 * 카드를 선택하면 호출되는 메소드
	 * 카드를 선택하던가, 이미 선택된 카드라면 선택이 해제됨 
	 * 선택된 카드가 세 장이 되면 선택된 카드들이 합인지 확인함
	 * 
	 * @pragma card : 화면에서 클릭된 Card 오브젝트의 Card 컴포넌트
	 */
	void	ClickCard(Card card)
	{
		if (card == null)
			return ;
		card.OnClick();
		int idx = seletedCards.FindIndex(x => x.index == card.index);
		if (idx == -1)
			seletedCards.Add(card);
		else
			seletedCards.RemoveAt(idx);
		seletedCards.Sort(new Comparison<Card>((x1, x2) => x1.index - x2.index));
		Debug.Log("Now seleted : " + string.Join(", ", seletedCards));
		if (seletedCards.Count == 3)
		{
			printEventPanelManager.showCheckPanel( setChecker.SetCheck(seletedCards) );
			for (int i = 0; i < seletedCards.Count; i++)
				seletedCards[i].OnClick(false);
			ResetSelete();
		}
		return ;
	}

	//선택된 Card 리스트를 초기화함
	public void	ResetSelete()
	{
		seletedCards.Clear();
		Debug.Log("Clear \"seletedCards\" in CardSelecter.cs");
		return ;
	}
}
