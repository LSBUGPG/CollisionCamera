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
		physics.position = target.position;
		physics.rotation = target.rotation;
		RaycastHit hitInfo;
		float distance = idealDistance;
		if (physics.SweepTest(-physics.transform.forward, out hitInfo, idealDistance))
		{
			distance = hitInfo.distance;
		}
		physics.position -= physics.transform.forward * distance;
	}
}