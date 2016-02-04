using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Planet class, unity compatible version of PlanetInfo class. 
/// It contains planet information gathered from db.
/// </summary>
public class Planet : MonoBehaviour
{
    // Planet information.
    public PlanetInfo planetInfo;
    public List<Tile> tiles;

    /// <summary>
    /// Default constructor. Only creates an empty instance of the object.
    /// </summary>
    public Planet()
    {
        tiles = new List<Tile>();
    }

    /// <summary>
    /// After object has been created, it should have initialized
    /// through this method.
    /// </summary>
    /// <param name="planetToken">JSON token of planet information.</param>
    public void GetPlanet(JToken planetToken)
    {
        planetInfo = new PlanetInfo(planetToken);
        foreach (var tile in planetInfo.tiles) {
            Tile uTile = gameObject.AddComponent<Tile>();
            uTile.tileInfo = tile;
            tiles.Add(uTile);
        }       
    }
}

