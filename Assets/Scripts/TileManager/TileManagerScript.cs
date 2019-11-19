using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    public static List<TileBaseScript> tilelist;
    // Start is called before the first frame update
    void Start()
    {
        if (tilelist == null)
            tilelist = new List<TileBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(TileBaseScript tile in tilelist)
        {
            //if (tile.type == "sliding") Destroy(tile.gameObject);
        }
    }

    public void AddTile(ref TileBaseScript go)
    {
        tilelist.Add(go);
    }
}
