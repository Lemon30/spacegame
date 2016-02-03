using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileMenuScript : MonoBehaviour {

	public void openMenu( string menuTag ){
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag) {
				Debug.Log ("TitaOpenMenu: " + menuTag);
				panel.position = new Vector3 (0, 0, 0);
			}
		}
	}
}
