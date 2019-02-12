using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
	[Tooltip("moving here")] public Transform target;
	[Tooltip("seconds to cover distance")] public float positionTime = 0.1f;
	[Tooltip("seconds to orientate")] public float rotationTime = 0.05f;
	Vector3 velocity;
	float angularVelocity;

	void LateUpdate()
	{
		transform.position = Vector3.SmoothDamp(
			transform.position,
			target.position,
			ref velocity,
			positionTime);
		float angle = Quaternion.Angle(transform.rotation, target.rotation);
		transform.rotation = Quaternion.RotateTowards(
			transform.rotation,
			target.rotation,
			Mathf.SmoothDampAngle(
				0.0f,
				angle,
				ref angularVelocity,
				rotationTime));
	}
}