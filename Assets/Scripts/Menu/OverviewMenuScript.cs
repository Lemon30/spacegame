using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverviewMenuScript : MonoBehaviour {

	public Text resourcesText;
	public Text planetTitleText;

	public void changeScene( string sceneName ){
		Application.LoadLevel ( sceneName ); // Says that LoadLevel is obsolete, change later
	}

	public void openMenu( string menuTag ){
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag)
				Debug.Log ("TitaOpenMenu" + menuTag);
				//panel.gameObject.SetActive (true);

		}
	}

	// Use this for initialization
	void Awake () {
		Transform trans = this.GetComponentInParent<Canvas> ().transform;
		Debug.Log (trans.name);
		int amountOfChildren = trans.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform childTrans = trans.GetChild (i);
			if (childTrans.gameObject.tag == "ResourcesText")
				resourcesText = childTrans.gameObject.GetComponent<Text> ();
			else if (childTrans.gameObject.tag == "PlanetTitleText")
				planetTitleText = childTrans.gameObject.GetComponent<Text> ();
		}
		planetTitleText.text = GameMaster.gameMaster.myPlanet.name;
	}

	// Update is called once per frame
	void Update () {
		resourcesText.text = GameMaster.gameMaster.titaniumVal + " :T" + "\n" +
			GameMaster.gameMaster.mineralVal + ":M" + "\n" +
			GameMaster.gameMaster.luminiteVal + " :L";
	}

	void OnGUI(){
		int tilePlace = 0;
		foreach (Tile tile in GameMaster.gameMaster.myTiles) {
			if (tile.building != null) {
				if (GUI.Button (new Rect (10, tilePlace, 150, 30), "Id: " + tile.id + " " + tile.building.name + "," + tile.building.level)) {
					tile.building.level++;
				}
			}
			tilePlace = tilePlace + 30;
		}
	}
}
