using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShowSetListManager : MonoBehaviour
{
	[SerializeField]
	private GameObject			showSet;

	private List<GameObject>	showSetList = new List<GameObject>();

	private Vector3				startPoint = new Vector3(-7, -4, 0);
	private Vector3				endPoint = new Vector3(7, -4, 0);

	// Start is called before the first frame update
	void Start()
	{
		showSetList.Clear();
		return ;
	}

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

	public void	ResetShowSetList()
	{
		for (int i = showSetList.Count - 1; i >= 0; i--)
			Destroy(showSetList[i]);
		showSetList.Clear();
		Debug.Log("Clear \"showSetList\" in ShowSetListManager.cs");
		return ;
	}
}
