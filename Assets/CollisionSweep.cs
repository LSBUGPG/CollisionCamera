using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionSweep : MonoBehaviour
{
	public Transform target;
	public float targetDistance = 10.0f;
	Rigidbody physics;
	Vector3 position;
	Quaternion rotation;

	void Awake()
	{
		physics = GetComponent<Rigidbody>();
	}

	void Update()
	{
		transform.position = target.position;
		transform.rotation = target.rotation;
		RaycastHit hitInfo;
		float distance = targetDistance;
		if (physics.SweepTest(-transform.forward, out hitInfo, targetDistance))
		{
			distance = hitInfo.distance;
		}
		transform.Translate(-transform.forward * distance, Space.World);
	}
}
