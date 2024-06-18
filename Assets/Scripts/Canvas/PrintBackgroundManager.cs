using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//배경화면을 담당하는 클래스
public class PrintBackgroundManager : MonoBehaviour
{
	//배경화면을 출력하는 오브젝트
	[SerializeField]
	private GameObject	background;
	//배경화면 이미지들
	[SerializeField]
	private Texture2D[]	textures;
	
	//실제로 출력되는 배경화면
	private	RawImage	image;
	//같은 이미지가 연속으로 배경화면으로 선저오디지 않도록 계산하기 위한 변수들
	private List<int>	bgList = new List<int>();
	private int			now;

	void	Awake()
	{
		image = background.GetComponent<RawImage>();
		for (int i = 0; i < textures.Length; i++)
			bgList.Add(i);
		now = Random.Range(0, textures.Length);
		bgList.Remove(now);
		return ;
	}

	//배경화면을 랜덤하게 변경함
	public void	Rollbackground()
	{
		SetImage(bgList[Random.Range(0, bgList.Count)]);
		return ;
	}

	//배경화면을 변경함
	void	SetImage(int i)
	{
		image.texture = textures[i];
		bgList.Add(now);
		bgList.Remove(i);
		now = i;
		return ;
	}
}
