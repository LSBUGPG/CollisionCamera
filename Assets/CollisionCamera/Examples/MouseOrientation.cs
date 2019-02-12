using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOrientation : MonoBehaviour
{
	[Tooltip("yaw, pitch in degrees per second")]
	public Vector2 speed = Vector2.one * 60.0f;
	float yaw;
	float pitch;

	void Update()
	{
		Vector2 movement = new Vector2(
			Input.GetAxis("Mouse X"),
			Input.GetAxis("Mouse Y")) * speed * Time.deltaTime;
		yaw += movement.x;
		pitch = Mathf.Clamp(pitch + movement.y, -85.0f, 85.0f);
		transform.rotation =
			Quaternion.AngleAxis(yaw, Vector3.up) *
			Quaternion.AngleAxis(pitch, Vector3.left);
	}
}