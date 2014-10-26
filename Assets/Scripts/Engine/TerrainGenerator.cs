using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TerrainGenerator : MonoBehaviour
{
    private enum SectionType
    {
        NONE,
        CONFIG,
        DATA,
        PREFABS
    }

    public TextAsset TerrainData;

    private Transform player;
    private GameObject[] Tileset = new GameObject[0];
    private int offset = 0;
    private SectionType parserMode = SectionType.NONE;
    private int currentLineNumber = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        foreach (string untrimedLine in TerrainData.text.Split(new Char[] { '\n' }))
        {
            string line = untrimedLine.Trim();
            if (IsData(line) && !isChangeModeLine(line))
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
        if (parameters.Length == 4)
        {
            Vector3 pos = new Vector3(
                int.Parse(parameters[1]),
                int.Parse(parameters[2]),
                int.Parse(parameters[3])
            );
            Instantiate(Resources.Load(parameters[0]), pos, Quaternion.identity);
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
