using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int numberOfObjects;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject downWall;
    [SerializeField] private GameObject superman;
    [SerializeField] private int supermanSpeed;
    [SerializeField] private byte power;
    private List<GameObject> targets;
    private GameObject currentTarget;
    private SpawnerUnits someSpawner;
    private bool isMove = false;

    private void Start()
    {
        someSpawner = new SpawnerUnits(objects, numberOfObjects, leftWall, rightWall, upWall, downWall);
        someSpawner.Spawn();
        targets = someSpawner.unitsList;
    }

    private void Update()
    {
        if (isMove)
        {
            MoveSuperman();
        }
        else
        {
            ChooseTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody enemyBody)) //Чтобы не было ошибок коллизии с плейном
        {
            Transform currentEnemy = collision.gameObject.transform;
            Vector3 kickDirection = currentEnemy.position - superman.transform.position;
            enemyBody.AddForce(kickDirection.normalized * power, ForceMode.Impulse);
            isMove = false;
        }
    }

    private void MoveSuperman()
    {
        Transform supTr = superman.transform;
        supTr.LookAt(currentTarget.transform);
        supTr.position = Vector3.MoveTowards
            (supTr.position, currentTarget.transform.position, Time.deltaTime * supermanSpeed);
        if (supTr.position == currentTarget.transform.position)
        {
            isMove = false;
        }
    }

    private void ChooseTarget()
    {
        currentTarget = targets[Random.Range(0, targets.Count)];
        // Можно раскомментить, чтобы исключить "союзников" из таргета
        //if (currentTarget.layer==8)
        //{
        //    ChooseTarget();
        //}
        isMove = true;
    }
}
