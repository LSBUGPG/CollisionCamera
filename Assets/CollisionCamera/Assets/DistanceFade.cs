using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DistanceFade : MonoBehaviour
{
	[Tooltip("distance from this position")] public Transform target;
	[Tooltip("at this distance in units")] public float startFade = 2.0f;
	[Tooltip("at this distance in units")] public float endFade = 1.0f;
	Material material;

	void Start()
	{
		Renderer renderer = GetComponent<Renderer>();
		material = renderer.material;
		renderer.material = material;
	}

	void Update()
	{
		float distance = Vector3.Distance(transform.position, target.position);
		Color colour = material.color;
		colour.a = Mathf.SmoothStep(
			0.0f,
			1.0f,
			Mathf.InverseLerp(endFade, startFade, distance));
		material.color = colour;
	}
}