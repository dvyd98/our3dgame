using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelFactoryScript : MonoBehaviour
{
    public GameObject normalTile;
    public GameObject slidingTile;
    public GameObject jumpTile;
    public GameObject blockObstacle;
    public GameObject woolBall;

    // Start is called before the first frame update
    void Start()
    {
        readTextFile("./Assets/Scripts/LevelFactory/level1.txt");
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
                if (tiles[i] == '.')
                {
                    GameObject obj = (GameObject)Instantiate(normalTile, new Vector3(-2 + i, 0, j), transform.rotation);
                    obj.transform.parent = transform;
                }
                else if (tiles[i] == 's')
                {
                    GameObject obj = (GameObject)Instantiate(slidingTile, new Vector3(-2 + i, 0, j), transform.rotation);
                    obj.transform.parent = transform;
                }
                else if (tiles[i] == 'j')
                {
                    GameObject obj = (GameObject)Instantiate(jumpTile, new Vector3(-2 + i, 0, j), transform.rotation);
                    obj.transform.parent = transform;
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
                }
            }

        }

    }
}
