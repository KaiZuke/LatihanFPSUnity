using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    private GameObject _enemy;
    private GameObject _boss;
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1.8f, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
        if (_boss == null)
        {
            _boss = Instantiate(bossPrefab) as GameObject;
            _boss.transform.position = new Vector3(0, 1.8f, 0);
            float angle = Random.Range(0, 360);
            _boss.transform.Rotate(0, angle, 0);
        }
    }
}
