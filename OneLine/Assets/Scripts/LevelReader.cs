﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Struct that stores the information of 1 level. This can be used to load
/// different levels from the JSON file "levels" and save them in an array
/// of Levels to retrieve their information later. 
/// </summary>
[System.Serializable]
public class Levels
{
    public int index; // Level number or index
    public string[] layout; // Map of the level 
    public Vector2[] path; // Solution
}

[System.Serializable]
public class LevelList
{
    public Levels[] Levels;
}

public class LevelReader
{
    LevelList list;

    public LevelReader(string filePath)
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);

            list = JsonUtility.FromJson<LevelList>(data);
        }
        else
        {
            Debug.LogError("Can not find data");
        }
    }
    public int GetNumLevels()
    {
        return list.Levels.Length;
    }

    public Levels GetLevel(int level)
    {
        return list.Levels[level - 1];
    }
}
