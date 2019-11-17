using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelFactoryScript : MonoBehaviour
{
    public GameObject normalTile;
    public GameObject slidingTile;
    public GameObject jumpTile;

    public TileManagerScript tileManager;

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

        //!inp_stm.EndOfStream)

        inp_stm.Close();
    }

    void loadLevel1(StreamReader reader)
    {
        string dim = reader.ReadLine();
        int x = int.Parse(dim.Split(' ')[0]);
        int z = int.Parse(dim.Split(' ')[1]);

        for (int j = 0; j < z; ++j)
        {
            string rowTiles = reader.ReadLine();
            for (int i = 0; i < x; ++i)
            {
                GameObject obj = null;
                if (rowTiles[i] == '.')
                {
                    obj = Instantiate(normalTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                }
                else if (rowTiles[i] == 's')
                {
                    obj = Instantiate(slidingTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                }
                else if (rowTiles[i] == 'j')
                {
                    obj = Instantiate(jumpTile, new Vector3(-2 + i, 0, j), transform.rotation) as GameObject;
                    obj.transform.parent = transform;
                }
                tileManager.AddTile(ref obj);
            }
        }
    }
}
