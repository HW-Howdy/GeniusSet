using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//상황에 맞추어 UI를 보여주는 클래스
public class PrintEventPanelManager : MonoBehaviour
{
	//각 상활별로 보여줄 Panels
	[SerializeField]
	private GameObject		startPanel;
	[SerializeField]
	private GameObject		checkPanelS;
	[SerializeField]
	private GameObject		checkPanelF;
	[SerializeField]
	private GameObject		shortagePanelS;
	[SerializeField]
	private GameObject		shortagePanelF;
	[SerializeField]
	private GameObject		timeoverPanel;

	//Panel을 보여주는 시간
	private readonly double	showTime = 1.0d;
	//Panel의 최대 투명도
	private readonly float	normalAlpha = 238.0f / 255.0f;

	//StartPanel을 보여줌
	public void	showStartPanel()
	{
		StopCoroutine(showStart());
		StartCoroutine(showStart());
		return ;
	}

	//success에 따른 CheckPanel을 보여줌
	public void showCheckPanel(bool success = false)
	{
		if (success)
		{
			StopCoroutine(showCheckS());
			StartCoroutine(showCheckS());
		}
		else
		{
			StopCoroutine(showCheckF());
			StartCoroutine(showCheckF());
		}
		return;
	}

	//success에 따른 ShortagePanel을 보여줌
	public bool showShortagePanel(bool success = false)
	{
		if (success)
		{
			StopCoroutine(showShortageS());
			StartCoroutine(showShortageS());
		}
		else
		{
			StopCoroutine(showShortageF());
			StartCoroutine(showShortageF());
		}
		return (success);
	}

	//TimeoverPanel을 보여줌
	public void showTimeoverPanel()
	{
		StopCoroutine(showTimeover());
		StartCoroutine(showTimeover());
		return;
	}

	IEnumerator showStart()
	{
		Image image = startPanel.GetComponent<Image>();
		Text text = startPanel.GetComponentInChildren<Text>();
		double rate = 1.0d / showTime;
		double now = showTime;

		startPanel.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha);
		text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha);
		while (now >= 0)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(now / showTime));
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(now / showTime));
		}
		startPanel.SetActive(false);
		yield break;
	}

	IEnumerator	showCheckS()
	{
		Image	image = checkPanelS.GetComponent<Image>();
		Text	text = checkPanelS.GetComponentInChildren<Text>();
		double	rate = 1.0d / showTime;
		double	now = showTime;

		checkPanelS.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha);
		text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha);
		while (now >= 0)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(now / showTime) );
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(now / showTime) );
		}
		checkPanelS.SetActive(false);
		yield break ;
	}

	IEnumerator showCheckF()
	{
		Image image = checkPanelF.GetComponent<Image>();
		Text text = checkPanelF.GetComponentInChildren<Text>();
		double rate = 1.0d / showTime;
		double now = showTime;

		checkPanelF.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha);
		text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha);
		while (now >= 0)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(now / showTime));
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(now / showTime));
		}
		checkPanelF.SetActive(false);
		yield break;
	}

	IEnumerator showShortageS()
	{
		Image image = shortagePanelS.GetComponent<Image>();
		Text text = shortagePanelS.GetComponentInChildren<Text>();
		double rate = 1.0d / showTime;
		double now = showTime;

		shortagePanelS.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
		while (now >= -showTime)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(showTime - Mathf.Abs( (float)(now / showTime) ) ) );
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(showTime - Mathf.Abs((float)(now / showTime) ) ) );
		}
		shortagePanelS.SetActive(false);
		yield break;
	}

	IEnumerator showShortageF()
	{
		Image image = shortagePanelF.GetComponent<Image>();
		Text text = shortagePanelF.GetComponentInChildren<Text>();
		double rate = 1.0d / showTime;
		double now = showTime;

		shortagePanelF.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
		while (now >= -showTime)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(showTime - Mathf.Abs((float)(now / showTime))));
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(showTime - Mathf.Abs((float)(now / showTime))));
		}
		shortagePanelF.SetActive(false);
		yield break;
	}
	IEnumerator showTimeover()
	{
		Image image = timeoverPanel.GetComponent<Image>();
		Text text = timeoverPanel.GetComponentInChildren<Text>();
		double rate = 1.0d / showTime;
		double now = showTime;

		timeoverPanel.SetActive(true);
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
		while (now >= -showTime)
		{
			yield return null;
			now -= rate * Time.deltaTime;
			image.color = new Color(image.color.r, image.color.g, image.color.b, normalAlpha * (float)(showTime - Mathf.Abs((float)(now / showTime))));
			text.color = new Color(text.color.r, text.color.g, text.color.b, normalAlpha * (float)(showTime - Mathf.Abs((float)(now / showTime))));
		}
		timeoverPanel.SetActive(false);
		yield break;
	}

}
