using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    [NonSerialized] public int _health = 100;
    public float radius = 70f;
    public GameObject bullet;
    public float attackInterval = 0.5f;
    private Coroutine _coroutine = null;

    private void Update()
    {
        DetectCollision();
        CheckHealth();
    }

    private void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0 && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        foreach (var el in hitColliders)
        {
            if (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player"))
            {
                GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(StartAttack(el.transform.position, el.gameObject));
                }
                break;
            }

            if (gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy"))
            {
                GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(StartAttack(el.transform.position, el.gameObject));
                }
                break;
            }
        }
    }

    IEnumerator StartAttack(Vector3 enemyPos, GameObject enemyObject)
    {
        while (true)
        {
            GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
            BulletController bulletController = obj.GetComponent<BulletController>();

            if (bulletController != null)
            {
                bulletController.position = enemyPos;
                enemyObject.GetComponent<CarAttack>().TakeDamage(30); // Наносим 30 урона врагу
            }

            yield return new WaitForSeconds(attackInterval);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
