using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TerrainGenerator : MonoBehaviour
{
    enum SectionType
    {
        None,
        Config,
        Data,
        Prefabs
    }

    public TextAsset TerrainData;

    Transform _player;
    GameObject[] _tileset = new GameObject[0];
    int _offset = 0;
    SectionType _parserMode = SectionType.None;
    int _currentLineNumber = 0;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        foreach (string untrimedLine in TerrainData.text.Split(new Char[] { '\n' }))
        {
            string line = untrimedLine.Trim();
            if (IsData(ref line) && !isChangeModeLine(line))
            {
                switch (_parserMode)
                {
                    case SectionType.Config:
                        ParseConfigLine(line);
                        break;
                    case SectionType.Data:
                        ParseDataLine(line);
                        break;
                    case SectionType.Prefabs:
                        ParsePrefabLine(line);
                        break;
                }

                _currentLineNumber++;
            }
        }
    }

    private bool IsData(ref string text)
    {
		if (text.Length == 0)
			return false;

		if (!HistoryMenu.HardDifficulty)
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
                _currentLineNumber = 0;
                _parserMode = SectionType.Config;
                return true;
            case "DATA_BEGIN":
                _currentLineNumber = 0;
                _parserMode = SectionType.Data;
                return true;
            case "PREFABS_BEGIN":
                _currentLineNumber = 0;
                _parserMode = SectionType.Prefabs;
                return true;
            case "END":
                _currentLineNumber = 0;
                _parserMode = SectionType.None;
                return true;
        }
        return false;
    }

    private void ParseConfigLine(string line)
    {
        if (_currentLineNumber == 0)
        {
            LoadTileset(int.Parse(line));
        }
        else if (_currentLineNumber == 1)
        {
            _offset = int.Parse(line);
        }
    }

    private void ParseDataLine(string line)
    {
        BuildTerrainLine(line, _currentLineNumber);
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
        _tileset = new GameObject[tilesetSize];
        for (int i = 0; i < tilesetSize; i++)
        {
            _tileset[i] = Resources.Load<GameObject>("Prefabs/Tiles/T" + i);
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
        if (tileID < _tileset.Length)
        {
            GameObject tile = Instantiate(_tileset[tileID],
                new Vector3(
                    _player.position.x + (xPos * _offset),
                    0.0f,
                    _player.position.z + (zPos * _offset)),
                Quaternion.identity) as GameObject;
            tile.transform.parent = transform;
        }
    }
}
