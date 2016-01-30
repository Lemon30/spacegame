using UnityEngine;
using System.Collections;

/// <summary>
/// Generates Unity3D compatible versions of
/// database objects.
/// </summary>
public class SpawnStarHelper : MonoBehaviour {

	public Star spawnedObj;

	/// <summary>
	/// Initializes a new instance of the <see cref="SpawnStarHelper"/> class.
	/// </summary>
	/// <param name="obj">Original Star object.</param>
	public SpawnStarHelper(Star obj){
		spawnedObj = obj;
	}
}
