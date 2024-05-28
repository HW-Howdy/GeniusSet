using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//현재 Stage가 몇인지 화면에 출력함
public class PrintStageManager : MonoBehaviour
{
	//화면에 Stage를 출력해줄 Text
	[SerializeField]
	private Text	stageText;

	//인자로 들어온 stage를 출력함
	public void	updateText(int stage, bool last = false)
	{
		stageText.text = "Stage : " + stage;
		if (last)
			stageText.color = Color.red;
		else
			stageText.color = Color.black;
		return ;
	}
}
