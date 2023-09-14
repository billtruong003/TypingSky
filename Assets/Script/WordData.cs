using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "WordData", menuName = "Typing Sky/WordData")]
public class WordData : ScriptableObject
{
    [SerializeField] private TextAsset jsonData;
    [SerializeField] public List<Data> WordsData;
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
    }
    [Serializable]
    public class Data
    {
        public string Word;
        public string Definition;
        public Difficulty Level;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LoadEasyWord()
    {
    }
    private class EasyWords
    {

    }
}
