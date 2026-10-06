using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreStat", menuName = "ScriptableObjects/ScoreStat", order = 2)]
public class ScoreStat : ScriptableObject
{
    public int score = 0;
}
