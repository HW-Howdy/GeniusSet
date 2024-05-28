using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ShowSet 프리팹에 적용된 클래스
public class ShowSetManager : MonoBehaviour
{
	//자식으로 보유한 Index들
	[SerializeField]
	private GameObject[]	indexObjs;

	//인자로 들어온 idxs로 자식 오브젝트 Index들을 초기화함
	public void	setting(int[] idxs)
	{
		if (idxs.Length != 3)
			return ;
		for (int i = 0; i < indexObjs.Length; i++)
		{
			indexObjs[i].GetComponent<ShowSetIndex>().SetIndex(idxs[i]);
		}
		Debug.Log("Set ShowSet with " + string.Join(", ", idxs) );
		return ;
	}
}
