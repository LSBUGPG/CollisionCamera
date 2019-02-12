using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionSweep : MonoBehaviour
{
	[Tooltip("sweeping back from this")] public Transform target;
	[Tooltip("units from target")] public float idealDistance = 10.0f;
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
		float distance = idealDistance;
		if (physics.SweepTest(-transform.forward, out hitInfo, idealDistance))
		{
			distance = hitInfo.distance;
		}
		transform.Translate(-transform.forward * distance, Space.World);
	}
}