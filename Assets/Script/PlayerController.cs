using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;

    [Header("Storage List")]
    [SerializeField] private List<GameObject> bullets;
    private Vector3 normalPos = new Vector3(0, 0, 90);
    private GameObject bullet;
    private int bulletIndex = 0;

    void Start()
    {
        player = gameObject;
        SetNormRotation();
        InitBullets();
    }

    void Update()
    {
        FaceToEnemy(enemy.transform);
    }
    private void SetNormRotation()
    {
        player.transform.localEulerAngles = normalPos;
    }
    private void FaceToEnemy(Transform EnemyPos) // Change to Enemy in each stage
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.right = EnemyPos.position - transform.position;
            Shoot(enemy);
            Debug.Log("Shoot");
        }
    }
    private void Shoot(GameObject target)
    {
        if (!CheckBulletExists())
        {
            bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = player.transform.parent.transform.GetChild(1);
            bullet.transform.localPosition = player.transform.localPosition;
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.Shoot(target);
            bullets.Add(bullet);
        }
        else
        {
            bullet = bullets[bulletIndex];
            bullet.SetActive(true);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bullet.transform.localPosition = player.transform.localPosition;
            bulletController.Shoot(target);
        }
    }
    private bool CheckCorrectInput()
    {
        return false;
    }
    private void CorrectWord()
    {
        FaceToEnemy(enemy.transform);
    }
    private bool CheckBulletExists()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            Debug.Log("check bullet");
            GameObject bullet = bullets[i];
            if (!bullet.activeInHierarchy)
            {
                bulletIndex = i;
                return true;
            }
        }
        Debug.Log("Bullet Not Found");
        return false;
    }
    private void InitBullets()
    {
        for (int i = 0; i < 15; i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullets.Add(bullet);
            bullet.transform.parent = bulletContainer.transform;
            bullet.SetActive(false);
        }
    }
}
