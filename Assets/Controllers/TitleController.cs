using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TitleController : MonoBehaviour {
	private Text title;
	public float timeLeft;
	const int fullDay = 60 * 60 * 24;

	public Camera camera;

	// Use this for initialization
	void Start () {
		title = GetComponent<Text> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		timeLeft = fullDay;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = timeLeft - Time.deltaTime;
		title.text = formatDate();
		setTheStyle ();
	}

	string formatDate () {
		int hours = (int)Math.Floor (timeLeft / 60 / 60);
		int hoursInSec = hours * 60 * 60;
		int minutes = (int)Math.Floor ((timeLeft - hoursInSec) / 60);
		int minutesInSec = minutes * 60;
		int secs = (int)Math.Floor ((timeLeft - hoursInSec - minutesInSec));
		return hours.ToString().PadLeft(2, '0') + ":" + minutes.ToString().PadLeft(2, '0') + ":" + secs.ToString().PadLeft(2, '0');
	}

	void setTheStyle() {
		if (timeLeft < (23 * 60 * 60)) {
			camera.backgroundColor = new Color (1.0f, 0.0f, 0.0f);
		} else {
			camera.backgroundColor = new Color (0.1f, 0.1f, 0.1f);
		}
	}

	public void resetTimer() {
		timeLeft = fullDay;
	}
}
