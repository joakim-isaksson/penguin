using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float Speed;

	[HideInInspector] public Transform Target;
	
	Vector3 offset;
	
	void Awake()
	{
		offset = transform.position;
	}

	void Update()
	{
		if (Target == null) return;

		var target = Target.transform.position + offset;
		var rubberBand =  Mathf.Pow(1 + Vector3.Distance(transform.position, target), 2);
		transform.position = Vector3.MoveTowards(transform.position, target, Speed * rubberBand * Time.deltaTime);
	}
	
	public static CameraController Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(CameraController).Name).GetComponent<CameraController>();
	}
}