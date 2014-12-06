using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TerrainGenerator : MonoBehaviour
{
    enum SectionType
    {
        NONE,
        CONFIG,
        DATA,
        PREFABS
    }

    public TextAsset TerrainData;

    Transform player;
    GameObject[] Tileset = new GameObject[0];

    int offset = 0;
    SectionType parserMode = SectionType.NONE;
    int currentLineNumber = 0;

    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        foreach (string untrimedLine in TerrainData.text.Split(new Char[] { '\n' }))
        {
            string line = untrimedLine.Trim();
            if (IsData(ref line) && !isChangeModeLine(line))
            {
                switch (parserMode)
                {
                    case SectionType.CONFIG:
                        ParseConfigLine(line);
                        break;
                    case SectionType.DATA:
                        ParseDataLine(line);
                        break;
                    case SectionType.PREFABS:
                        ParsePrefabLine(line);
                        break;
                }

                currentLineNumber++;
            }
        }
    }

    private bool IsData(ref string text)
    {
		if (text.Length == 0)
			return false;

		if (!HistoryMenu.hardDifficulty)
			return text[0] != '#' && text[0] != '*';

		if (text[0] == '*') {
			text = text.Replace('*', ' ');
			text = text.TrimStart();
			return true;
		} 
		return text[0] != '#' && text[0] != '*';
    }

	private bool IsData(string text)
	{
		return text.Length > 0 && text[0] != '#';
	}

    private bool isChangeModeLine(string line)
    {
        switch (line)
        {
            case "CONFIG_BEGIN":
                currentLineNumber = 0;
                parserMode = SectionType.CONFIG;
                return true;
            case "DATA_BEGIN":
                currentLineNumber = 0;
                parserMode = SectionType.DATA;
                return true;
            case "PREFABS_BEGIN":
                currentLineNumber = 0;
                parserMode = SectionType.PREFABS;
                return true;
            case "END":
                currentLineNumber = 0;
                parserMode = SectionType.NONE;
                return true;
        }
        return false;
    }

    private void ParseConfigLine(string line)
    {
        if (currentLineNumber == 0)
        {
            LoadTileset(int.Parse(line));
        }
        else if (currentLineNumber == 1)
        {
            offset = int.Parse(line);
        }
    }

    private void ParseDataLine(string line)
    {
        BuildTerrainLine(line, currentLineNumber);
    }

    private void ParsePrefabLine(string line)
    {
        String[] parameters = line.Split(new Char[] { ':' });
        if (parameters.Length >= 4)
        {
			String goName = parameters[0];
			GameObject res = Resources.Load(goName) as GameObject;
			if(!res){
				throw new Exception("Le préfab " + goName + " n'existe pas");
			}
            Vector3 pos = new Vector3(
				parseNumber(parameters[1]),
				parseNumber(parameters[2]),
				parseNumber(parameters[3])
            );
			Quaternion rotation = Quaternion.identity;
			if(parameters.Length >= 5){
				rotation = Quaternion.AngleAxis(parseNumber (parameters[4]), Vector3.up);
			}
			Instantiate(res, pos, rotation);
        }
    }

    private void LoadTileset(int tilesetSize)
    {
        Tileset = new GameObject[tilesetSize];
        for (int i = 0; i < tilesetSize; i++)
        {
            Tileset[i] = Resources.Load<GameObject>("Prefabs/Tiles/T" + i);
        }
    }

    private void BuildTerrainLine(string tilesIDs, int zPos)
    {
        int xPos = 0;
        foreach (string tileID in tilesIDs.Split(new Char[] { ' ', '\t' }))
        {
            if (IsData(tileID))
            {
                BuildTile(int.Parse(tileID), xPos, zPos);
                xPos++;
            }
        }
    }

	private float parseNumber(String num){
		return float.Parse(num);
	}

    private void BuildTile(int tileID, int xPos, int zPos)
    {
        if (tileID < Tileset.Length)
        {
            GameObject tile = Instantiate(Tileset[tileID],
                new Vector3(
                    player.position.x + (xPos * offset),
                    0.0f,
                    player.position.z + (zPos * offset)),
                Quaternion.identity) as GameObject;
            tile.transform.parent = transform;
        }
    }
}
