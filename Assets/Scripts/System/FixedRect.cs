﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//화면 UI의 해상도를 조절하는 클래스
public class FixedRect : MonoBehaviour
{
	private void Start()
	{
		SetResolution();
	}

	public void SetResolution()
	{
		int	setWidth = 1920;
		int	setHeight = 1080;
		int	deviceWidth = Screen.width;
		int	deviceHeight = Screen.height;

		Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true);
		if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight)
		{
			float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight);
			Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
		}
		else
		{
			float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight);
			Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
		}
	}
}
