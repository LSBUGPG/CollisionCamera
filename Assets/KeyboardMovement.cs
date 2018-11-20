using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
	public float speed = 1.0f;

	void Update()
	{
		Vector3 forward = Vector3.Cross(transform.right, Vector3.up) * Input.GetAxis("Vertical");
		Vector3 right = transform.right * Input.GetAxis("Horizontal");
		transform.Translate((forward + right) * speed * Time.deltaTime, Space.World);
	}
}
