using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    public static List<GameObject> tilelist;
    // Start is called before the first frame update
    void Start()
    {
        if (tilelist == null)
            tilelist = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in tilelist)
        {
            
        }
    }

    public void AddTile(ref GameObject go)
    {
        tilelist.Add(go);
    }
}
