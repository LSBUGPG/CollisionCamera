using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFade : MonoBehaviour
{
	public Transform target;
	public float startFade = 2.0f;
	public float endFade = 1.0f;
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
		colour.a = Mathf.InverseLerp(endFade, startFade, distance);
		material.color = colour;
	}
}
