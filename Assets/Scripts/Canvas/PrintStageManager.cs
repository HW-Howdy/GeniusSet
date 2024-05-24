using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintStageManager : MonoBehaviour
{
	[SerializeField]
	private Text	stageText;

	public void	updateText(int stage)
	{
		stageText.text = "Stage : " + stage;
		return ;
	}
}
