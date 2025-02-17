using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttackMeter : MonoBehaviour
{
	[SerializeField] Vector2 offsetFromMouse;
	Canvas canvas;
	Slider slider;
	TMP_Text text;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		slider = GetComponentInChildren<Slider>();
		text = GetComponentInChildren<TMP_Text>();
	}

	void OnEnable()
	{
		PlayerBasicAttack.OnCharge += () => canvas.enabled = true;
		PlayerBasicAttack.OnFire += () => canvas.enabled = false;
	}
	void OnDisable()
	{
		PlayerBasicAttack.OnCharge -= () => canvas.enabled = true;
		PlayerBasicAttack.OnFire -= () => canvas.enabled = false;
	}

	void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePos + offsetFromMouse;

		float counter = PlayerBasicAttack.Instance.chargeCounter;
		float duration = PlayerBasicAttack.Instance.chargeDuration;
		slider.value = counter / duration;

		if (counter >= duration) text.enabled = true;
		else text.enabled = false;
	}
}
