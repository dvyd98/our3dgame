using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelFactoryScript : MonoBehaviour
{
    public string level;

    public GameObject normalTile;
    public GameObject slidingTile;
    public GameObject slidingGroup;
    public GameObject jumpTile;
    public GameObject blockObstacle;
    public GameObject woolBall;
    public GameObject magneticTileB;
    public GameObject magneticTileF;
    public GameObject magneticTileL;
    public GameObject magneticTileR;
    public GameObject fallingTile;
    public GameObject anvil;

    public TileBaseScript tile;

    // Start is called before the first frame update
    void Start()
    {
        readTextFile("./Assets/Scripts/LevelFactory/" + level + ".txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        string title = inp_stm.ReadLine();
        if (title == "LEVEL1") loadLevel1(inp_stm);

        inp_stm.Close();
    }

    void loadLevel1(StreamReader reader)
    {
        string dim = reader.ReadLine();
        int x = int.Parse(dim.Split(' ')[0]);
        int z = int.Parse(dim.Split(' ')[1]);

        for (int j = 0; j < z; ++j)
        {
            string[] rowTiles = reader.ReadLine().Split('|');

            string tiles = rowTiles[0];
            string obstacles = (rowTiles.Length == 2) ? rowTiles[1] : "";


            for (int i = 0; i < x; ++i)
            {
                GameObject obj = null;
                if (tiles[i] == '.')
                {
                    obj = Instantiate(normalTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponent<TileBaseScript>();
                }
                else if (tiles[i] == 's')
                {
                    obj = Instantiate(slidingTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponent<SlidingTileMoveScript>();
                }
                else if (tiles[i] == 'z')
                {
                    obj = Instantiate(slidingGroup, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponent<SlidingTileMoveScript>();
                }
                else if (tiles[i] == 'j')
                {
                    obj = Instantiate(jumpTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponent<CollisionActionScript>();
                }
                else if (tiles[i] == 'b')
                {
                    obj = Instantiate(magneticTileB, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponent<MagneticTileBaseScript>();
                }
                else if (tiles[i] == 'f')
                {
                    obj = Instantiate(magneticTileF, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponentInChildren<MagneticTileForwardScript>();
                }
                else if (tiles[i] == 'l')
                {
                    obj = Instantiate(magneticTileL, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponentInChildren<MagneticTileForwardScript>();
                }
                else if (tiles[i] == 'r')
                {
                    obj = Instantiate(magneticTileR, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponentInChildren<MagneticTileForwardScript>();
                }
                else if (tiles[i] == 'g')
                {
                    obj = Instantiate(fallingTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                    tile = obj.GetComponentInChildren<MagneticTileForwardScript>();
                }

            }

            if (obstacles.Length != 0)
            {
                for (int i = 0; i < x; ++i)
                {
                    if (obstacles[i] == 'b')
                    {
                        GameObject obj = (GameObject)Instantiate(blockObstacle, new Vector3(-2 + i, 0.3f, j), transform.rotation);
                        obj.transform.parent = transform;
                    }
                    if (obstacles[i] == 'w')
                    {
                        GameObject obj = (GameObject)Instantiate(woolBall, new Vector3(-2 + i, 0.5f, j), transform.rotation);
                        obj.transform.parent = transform;
                    }
                    if (obstacles[i] == 'a')
                    {
                        GameObject obj = (GameObject)Instantiate(anvil, new Vector3(-2 + i, 1.5f, j), transform.rotation);
                        obj.transform.parent = transform;
                    }
                }
            }

        }

    }
}
