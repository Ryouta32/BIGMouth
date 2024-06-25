using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-103)]
public class BuildNavmesh : MonoBehaviour
{
	void Update()
	{
		GetComponent<NavMeshSurface>().BuildNavMesh();
	}
}
