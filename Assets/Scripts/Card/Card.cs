using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//게임의 핵심이 되는 Card
public class Card : MonoBehaviour
{
	//각 카드를 쉽게 구분하기 위한 정보. 초기화는 에디터에서 이루어짐
	public int index;

	//자식 게임오브젝트를 가리킴
	[SerializeField]
	private GameObject	head;
	[SerializeField]
	private GameObject	body;
	[SerializeField]
	private GameObject	selete;

	//자식 오브젝트의 유형 별 모양을 가리킴. 상점 도입 시 이 부분을 고쳐 스킨을 제작할 수 있을 듯함
	[SerializeField]
	private Sprite[]	headTypes;
	[SerializeField]
	private Color[]		headColors;
	[SerializeField]
	private Color[]		bodyColors;
	[SerializeField]
	private Vector3[]	scales;
	[SerializeField]
	private Vector3[]	positions;

	//카드의 유형. 유형에 따라 위의 정보에 따라 자식 오브젝트를 수정함
    private int			headType;
    private int			headColor;
	private int			bodyColor;
	//카드가 플레이어에 의해 선택되었는지 여부
	private bool		state;

	//카드의 유형을 외부에서 접근 가능하도록 하였음
	public int			HeadType { get => headType; set => headType = value; }
    public int			HeadColor { get => headColor; set => headColor = value; }
    public int			BodyColor { get => bodyColor; set => bodyColor = value; }

	// Start is called before the first frame update
	private void	Start()
	{
		cardSetting();
		return ;
	}

	//주어진 정보에 따라 Card를 설정함
	public void	cardSetting()
	{
		head.GetComponent<SpriteRenderer>().sprite = headTypes[headType];
		head.GetComponent<SpriteRenderer>().color = headColors[headColor];
		body.GetComponent<SpriteRenderer>().color = bodyColors[bodyColor];
		state = false;
		selete.SetActive(state);
		head.transform.localScale = scales[headType];
		head.transform.position = body.transform.position + positions[headType];
		return ;
	}

	//플레이어에 의해 Card가 클릭되면, state를 변경함
	public void	OnClick(bool flag = true)
	{
		if (flag)
			state = !state;
		else
			state = false;
		selete.SetActive(state);
		return ;
	}
	
	//카드 타입을 배열화하여 반환함
	public int[] getCardType()
	{
		int[] result = new int[] { headType, headColor, bodyColor };
		return (result);
	}
	
}
