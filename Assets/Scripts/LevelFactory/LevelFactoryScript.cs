using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelFactoryScript : MonoBehaviour
{
    public GameObject normalTile;

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
                if (rowTiles[i] == '.')
                {
                    GameObject obj = (GameObject)Instantiate(normalTile, new Vector3(-2 + i, 0, j), transform.rotation);
                    obj.transform.parent = transform;
                }
            }
        }
    }
}
