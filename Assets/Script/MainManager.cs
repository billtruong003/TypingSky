using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] private SpriteConfig m_spriteConfig;
    [SerializeField] private PrefabConfig m_prefabConfig;
    [SerializeField] private GameObject m_player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {

    }
    private void InitPlayer()
    {
        m_player = GameObject.Instantiate(m_prefabConfig.GetPrefab("Player"));
        Sprite playerSprite = m_player.GetComponentInChildren<Sprite>();
        playerSprite = m_spriteConfig.GetPlayerSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetEnemy()
    {
        return gameObject;
    }

}
