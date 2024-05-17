using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSetManager : MonoBehaviour
{
	[SerializeField]
	private GameObject[]	indexObjs;

	public void	setting(int[] idxs)
	{
		if (idxs.Length != 3)
			return ;
		for (int i = 0; i < idxs.Length; i++)
		{
			indexObjs[i].GetComponent<ShowSetIndex>().SetIndex(idxs[i]);
		}
		Debug.Log("Set ShowSet with " + string.Join(", ", idxs) );
		return ;
	}
}
