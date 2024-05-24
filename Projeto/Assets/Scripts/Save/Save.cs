using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public List<float> position;
    //public bool sound;
    //public float volume;
    public int life;
    public int coins;
    public int advices;
    public int tips;
    public int m2;
    public bool partner;
    public List<Mission> missions;
    public bool[] dialogue;
}
