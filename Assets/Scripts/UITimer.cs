using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
	public TextMeshProUGUI TimerText;
	public bool playing;
	private float Timer;
	public bool gameOver;
	private int seconds;
	private float endTime = 20.5f;
	public GameManager gameManager; 
	

	void Start()
	{
		gameOver = false;
	}
	public void Update()
	{
		if(gameManager.isGameActive)
        {
			TimerRoutine();
        }
	}

	void TimerRoutine()
    {
		Timer += Time.deltaTime;

		seconds = Mathf.FloorToInt(Timer % 60F);

		if (seconds >= endTime)
		{
			gameOver = true;
		}
		else if (gameOver == false)
		{
			TimerText.text = "Time: " + seconds.ToString("00");
		}
	}
}