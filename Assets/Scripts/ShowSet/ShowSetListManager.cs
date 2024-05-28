using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


//플레이어가 찾은 세트들을 화면에 출력하는 클래스
public class ShowSetListManager : MonoBehaviour
{
	//화면에 출력된 양식(prefab)
	[SerializeField]
	private GameObject			showSet;

	//화면에 출력되고 있는 ShowSet 리스트
	private List<GameObject>	showSetList = new List<GameObject>();

	//ShowSet이 화면에 출력될 범위의 시점과 종점 (직선)
	private Vector3				startPoint = new Vector3(-7, -4, 0);
	private Vector3				endPoint = new Vector3(7, -4, 0);

	// Start is called before the first frame update
	void Start()
	{
		showSetList.Clear();
		return ;
	}

	/*
	 * 인자로 들어온 index를 ShowSet에 입력하고 화면에 출력해줌
	 * 화면에 출력할 때, 기존 ShowSet의 위치를 조절하여 직선으로 정렬되게 함
	 * 
	 * @pragma index : 합으로 판명된 Card의 인덱스 3개가 오름차순 정렬된 int 배열
	 */
	public void	addShowSetList(int[] index)
	{
		GameObject	newShowSet = Instantiate(showSet);
		Vector3		distance;

		newShowSet.GetComponent<ShowSetManager>().setting(index);
		showSetList.Add(newShowSet);
		distance = (endPoint - startPoint) / showSetList.Count;
		for (int i = 0; i < showSetList.Count; i++)
		{
			showSetList[i].transform.position = startPoint + distance * (i + 0.5f);
		}
		return ;
	}

	//화면에 보이는 ShowSet을 모두 없앰
	public void	ResetShowSetList()
	{
		for (int i = showSetList.Count - 1; i >= 0; i--)
			Destroy(showSetList[i]);
		showSetList.Clear();
		Debug.Log("Clear \"showSetList\" in ShowSetListManager.cs");
		return ;
	}
}
