using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOrientation : MonoBehaviour
{
	public Vector2 speed = Vector2.one * 60.0f;
	Vector2 direction = Vector2.zero;
	void Update()
	{
		Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * speed * Time.deltaTime;
		direction.x += movement.x;
		direction.y = Mathf.Clamp(direction.y + movement.y, -85.0f, 85.0f);
		transform.rotation = Quaternion.AngleAxis(direction.x, Vector3.up) * Quaternion.AngleAxis(direction.y, Vector3.left);
	}
}
