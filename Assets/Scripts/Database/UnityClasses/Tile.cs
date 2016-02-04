using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Tile class is unity compatible tile class.
/// Contains tile info and used for unity object
/// spawn.
/// </summary>
public class Tile : MonoBehaviour {

    // Tile information.
    public TileInfo tileInfo;

    /// <summary>
    /// Creates empty instance of tile object.
    /// </summary>
    public Tile() { }
    
    /// <summary>
    /// Initializes empty Tile instance.
    /// </summary>
    /// <param name="tileToken">JSON token that contains tile information.</param>
    public void GetTile(JToken tileToken)
    {
        tileInfo = new TileInfo(tileToken);
    }
	
}
