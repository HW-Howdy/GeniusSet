using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	private int							time = 0;
	[SerializeField]
	private int							timePerStage = 60;
	[SerializeField]
	private Text						timeText;

	private delegate void				TimeOverMethod();
	private static event TimeOverMethod	TimeOverEvent;

	public int							getTime { get => time; }

	// Start is called before the first frame update
	void Start()
	{
		time = timePerStage;
		StartCoroutine(CountDown());
		TimeOverEvent += GameObject.Find("StageMaster").GetComponent<StageManager>().TimeOverEvent;
		return ;
	}

	public void	ResetTime()
	{
		time = timePerStage;
		StopAllCoroutines();
		StartCoroutine(CountDown());
		Debug.Log("Set Time : " + time);
		return ;
	}

	void	TimeOver()
	{
		StopAllCoroutines();
		TimeOverEvent();
		return ;
	}

	public void updateText()
	{
		timeText.text = "TIME : " + time;
		return ;
	}

	IEnumerator	CountDown()
	{
		bool	flag = true;

		updateText();
		while (flag)
		{
			yield return (new WaitForSeconds(1.0f));
			time--;
			updateText();
			if (time <= 0)
				TimeOver();
		}
		yield break ;
	}
}
