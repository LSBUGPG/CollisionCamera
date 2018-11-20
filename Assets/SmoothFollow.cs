using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
	public Transform target;
	public float time = 1.0f; // time to cover distance
	public float distance = 0.8f; // fraction of distance to cover

	float calculateInterpolation(float proportion, float time, float deltaTime)
	{
		return 1.0f - Mathf.Pow(1.0f - proportion, deltaTime / time);
	}

	void Update()
	{
		float interpolation = calculateInterpolation(distance, time, Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, target.position, interpolation);
		transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, interpolation);
	}
}
