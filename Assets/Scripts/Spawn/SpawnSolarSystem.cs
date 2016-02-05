using UnityEngine;
using System.Collections;

public class SpawnSolarSystem : MonoBehaviour {

	public GameObject star3DPrefab;
	public GameObject planet3DPrefab;

	Star star;
	Planet planet;
	TextMesh textObject;

	public void Spawn() {
		star = GameMaster.gameMaster.selectedStar;

		// Create the star at the center
		GameObject newStar = (GameObject)Instantiate (star3DPrefab, new Vector3 (-500, 0, 0), Quaternion.identity);
		newStar.name = star.starInfo.name;
		textObject = newStar.GetComponentInChildren<TextMesh> ();
		textObject.text = "\t" + newStar.name;
		textObject.color = Color.cyan;

		// Create planets one by one
		int amountOfPlanets = star.starInfo.planets.Count;
		for (int i = 0; i < amountOfPlanets; i++) {
			planet = star.planets [i];
			GameObject newPlanet = (GameObject)Instantiate (planet3DPrefab, new Vector3 (-500 + (i+1)*2, 0, 0), Quaternion.identity);
			newPlanet.name = planet.planetInfo.name;
			textObject = newPlanet.GetComponentInChildren<TextMesh> ();
			textObject.text = "\t" + newPlanet.name;
			textObject.color = Color.cyan;
		}

	}

}
