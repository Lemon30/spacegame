using UnityEngine;
using System.Collections;

public class SpawnSolarSystem : MonoBehaviour {

	public GameObject star3DPrefab;
	Star star;

	public void Spawn() {
		star = GameMaster.gameMaster.selectedStar;
		Debug.Log ("Hello: " + star.starInfo.name );

		GameObject newStar = (GameObject)Instantiate (star3DPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
