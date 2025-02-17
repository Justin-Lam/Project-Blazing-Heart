using System.Collections;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Fire(float velocity, float lifespan)
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 dir = mousePos - (Vector2)transform.position;
		rb.velocity = dir.normalized * velocity;
		StartCoroutine(countdownToDeath(lifespan));
	}

	IEnumerator countdownToDeath(float lifespan)
	{
		yield return new WaitForSeconds(lifespan);
		gameObject.SetActive(false);
	}
}
