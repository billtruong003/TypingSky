using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private GameObject target;
    [SerializeField] private bool collideEnemy = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
            Debug.Log("Trigger");
            gameObject.SetActive(false);
            collideEnemy = true;
        }
    }
    public void SetTarget(GameObject targetset)
    {
        target = targetset;
    }
    public void Shoot(GameObject EnemyTarget)
    {
        collideEnemy = false;
        SetTarget(EnemyTarget);
        StartCoroutine(ShootOutBullet(target));
    }
    private IEnumerator ShootOutBullet(GameObject target)
    {
        while (!collideEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
            transform.up = target.transform.position - transform.position;
            yield return null;
        }
    }
}
