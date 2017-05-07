using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
	public float speed;

	private Text text;
	private string message;

	void Start()
  {
		text = GetComponent<Text>();
		message = text.text;
	}

	void Update()
  {
		float v = Mathf.PingPong(Time.time * speed, 1.0f);
		bool show = Mathf.Round(v) > 0;
		text.text = show ? message : "";
	}
}
