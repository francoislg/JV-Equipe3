using UnityEngine;
using System.Collections;

public class TerrainGen : MonoBehaviour {
    public Transform Player;
    public Transform T01;
    public Transform T02;
    public Transform T03;
    public Transform T04;
    public Transform T05;
    public Transform T06;
    public Transform T07;
    public Transform T08;
    public Transform T09;
    private Transform[] tileset = new Transform[10];

    public TextAsset level0;

    private int offset = 20; //TODO : changer offset hardcodé pour venir du fichier de paramètres

	// Use this for initialization
	void Start () {
        InitTileset();

        int terrainXOrigin = (int)(Player.position.x);// -(offset / 2);
        int terrainZOrigin = (int)(Player.position.z);// -(offset / 2);
    
        int width = charToInt(level0.text[0]);
        int nbOfTiles = level0.text.Length - 2;
        char[] tiles = level0.text.ToCharArray(2, nbOfTiles);        

        for (int i = 0; i < tiles.Length; i++)
        {
            int tileID = charToInt(tiles[i]);
            int xPos = (i / width);
            int zPos = i % width;
            if (tileset[tileID] != null)
            {
                Instantiate(tileset[tileID], new Vector3(terrainXOrigin + (xPos * offset), 0, terrainZOrigin +(zPos * offset)), Quaternion.identity);
            }
            //Debug.Log("Largeur : " + width + " -- xPos : " + xPos +
            //    "-- zPos : " + zPos + " -- TileID : " + tileID);
        }
	}

    // Update is called once per frame
    void Update()
    {
       
	}

    // TODO : changer initialisation pour utiliser un fichier pour charger le tileset
    private void InitTileset()
    {
        tileset[0] = null;
        tileset[1] = T01;
        tileset[2] = T02;
        tileset[3] = T03;
        tileset[4] = T04;
        tileset[5] = T05;
        tileset[6] = T06;
        tileset[7] = T07;
        tileset[8] = T08;
        tileset[9] = T09;
    }

    private int charToInt(char iChar)
    {
        return int.Parse(iChar.ToString());
    }
}
