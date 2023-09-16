using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

[CreateAssetMenu(fileName = "SpriteData", menuName = "Typing Sky/Sprite Asset/SpriteData")]
public class SpriteConfig : ScriptableObject
{
    [Serializable]
    public class Enemy
    {
        public string EnemyName;
        public string SourcePath;
    }

    [Serializable]
    public class Player
    {
        public string PlayerName;
        public string SourcePath;
        public Color BulletCol;
    }

    private const string PATH_RESOURCES = "Resources/";

    public List<Player> PlayerDatas;
    public List<Enemy> EnemyDatas;

    public Sprite GetPlayerSprite()
    {
        Sprite Psprite;
        int rndIndexSprite = UnityEngine.Random.Range(0, PlayerDatas.Count);
        string spritePath = PlayerDatas[rndIndexSprite].SourcePath;
        Psprite = Resources.Load<Sprite>(spritePath);
        return Psprite;
    }
    public Sprite GetEnemySprite()
    {
        Sprite Esprite;
        int rndIndexSprite = UnityEngine.Random.Range(0, EnemyDatas.Count);

        string spritePath = EnemyDatas[rndIndexSprite].SourcePath;
        Esprite = Resources.Load<Sprite>(spritePath);
        return Esprite;
    }

#if UNITY_EDITOR
    [SerializeField] private int enemySpriteNum = 10;
    [SerializeField] private int playerSpriteNum = 6;

    [Button]
    public void FillSourcePath()
    {
        PlayerDatas = new List<Player>();
        EnemyDatas = new List<Enemy>();

        for (int i = 0; i < enemySpriteNum; i++)
        {
            Enemy enemyData = new Enemy();
            enemyData.EnemyName = "ship " + "(" + (i + 1).ToString() + ")";
            enemyData.SourcePath = PATH_RESOURCES + enemyData.EnemyName;
            EnemyDatas.Add(enemyData);
        }

        for (int i = 0; i < playerSpriteNum; i++)
        {
            Player playerData = new Player();
            playerData.PlayerName = "ship " + "(" + (i + 1).ToString() + ")";
            playerData.SourcePath = $"{PATH_RESOURCES}{playerData.PlayerName}";
            PlayerDatas.Add(playerData);
        }
    }
#endif
}
