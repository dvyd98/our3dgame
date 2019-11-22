using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticTileBaseScript : TileBaseScript
{
    // Start is called before the first frame update
    void Start()
    {
        type = "magneticbase";
        count = 5;
        speed = 6;
    }
}
