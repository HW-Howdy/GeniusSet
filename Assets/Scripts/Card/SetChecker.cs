using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//선택된 카드들이 합인지, 현재 결을 선언할 수 있는지 체크함
public class SetChecker : MonoBehaviour
{
	//현재 카드 배치에서 나올 수 있는 세트의 모음
	private List<int[]>			setList =  new List<int[]>();
	//현재 카드 배치에서 플레이어가 찾은 세트의 모음
	private List<int[]>			foundSetList = new List<int[]>();

	//외부에서 참조할 수 있으니 열어둠
	public List<int[]>			SetList { get => setList; }
	public List<int[]>			FoundSetList { get => foundSetList; }

	//플레이어가 찾은 세트 목록을 화면에 출력해주는 클래스
	private ShowSetListManager	showSetListManager;

	private void Start()
	{
		showSetListManager = GameObject.Find("ShowSetListMaster").GetComponent<ShowSetListManager>();
		return ;
	}

	//파라미터로 들어온 cards가 세트인지 확인하고 세트라면 setList에 추가함
	public bool	SetCheck(List<Card> cards)
	{
		bool	result = false;

		if ( IsSet(cards) )
		{
			int[] found = new int[] { cards[0].index, cards[1].index, cards[2].index };
			if (setList.FindIndex(x => x.SequenceEqual(found)) == -1)
			{
				result = true;
				setList.Add(found);
				showSetListManager.addShowSetList(found);
				Debug.Log("new set found! : " + string.Join(", ", setList[setList.Count - 1]));
				Debug.Log("now setList Count : " + setList.Count);
			}
		}
		return (result);
	}

	//현재 필드가 결을 선언할 수 있는지 체크함
	public bool	ShortageCheck()
	{
		if (setList.Count == foundSetList.Count)
			return (true);
		else
			return (false);
	}

	//파라미터로 들어온 cards에 있는 모든 세트를 찾아 foundSetList에 저장함
	public void	FindAllSet(List<Card> cards)
	{
		foundSetList.Clear();
		for (int i = 0; i < cards.Count - 2; i++)
		{
			for (int j = i + 1;  j < cards.Count - 1; j++)
			{
				for (int k = j + 1; k < cards.Count; k++)
				{
					if ( IsSet(new List<Card>() { cards[i], cards[j], cards[k] } ) )
						foundSetList.Add(new int[] { cards[i].index, cards[j].index, cards[k].index });
				}
			}
		}
		Debug.Log("Found Set is " + foundSetList.Count);
		return ;
	}

	//파라미터로 들어온 cards가 세트라면 true, 아니라면 false를 반환
	private bool	IsSet(List<Card> cards)
	{
		bool	result = true;
		int		idx = -1;

		if (cards == null || cards.Count != 3)
			return (false);
		while (result && ++idx < cards.Count)
		{
			if (!CheckThreeEqualOrDifferent(	cards[0].getCardType()[idx],
												cards[1].getCardType()[idx],
												cards[2].getCardType()[idx]))
			{
				result = false;
			}
		}
		return (result);
	}

	//check 3 parameter, if there all are Equal or Diffenrent return true. else, return false
	bool CheckThreeEqualOrDifferent(int a, int b, int c)
	{
		if ( (a == b && b == c) || (a != b && b != c && a != c) )
			return (true);
		else
			return (false);
	}

	//setList를 초기화
	public void ResetSetList()
	{
		Debug.Log("Clear \"setList\" in SetChecker.cs");
		setList.Clear();
		return ;
	}
}