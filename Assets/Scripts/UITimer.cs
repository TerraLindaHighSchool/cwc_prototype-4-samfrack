using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
	public TextMeshProUGUI TimerText;
	public bool playing;
	private float Timer;
	public bool gameOver;
	

	void Start()
	{
		gameOver = false;
	}
	void Update()
	{
		Timer += Time.deltaTime;

		int seconds = Mathf.FloorToInt(Timer % 60F);
		int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
		if (seconds == 15)
		{
			gameOver = true;
			
			Timer = 15f;
			Debug.Log("Game Over");
		}
		else if (gameOver == false)
        {
			TimerText.text = seconds.ToString("00") + ":" + milliseconds.ToString("00");
		}
		
		void TimerRoutine()
        {


        }
	}

	

}