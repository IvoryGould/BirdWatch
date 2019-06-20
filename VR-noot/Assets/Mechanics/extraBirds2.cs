using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraBirds2 : MonoBehaviour
{
    private Vector3 point;
    private Vector3 homePoint;
    [SerializeField]
    private int birdPoints;

    public Transform[] target;
    public Transform[] homeTarget;
    public float speed;
    [HideInInspector]
    public float step;

    private void Start()
    {
        step = speed * Time.deltaTime;
        point = this.transform.position;
        homePoint = this.transform.position;
        StartCoroutine(NextPoint());
        birdPoints = 0;
    }
    private void Update()
    {
        // Send the birds to a different point
        if (birdPoints <= 10)
        {
            StopCoroutine(SpawnPoint());
            transform.position = Vector3.MoveTowards(transform.position, point, step);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, point - transform.position, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else if (birdPoints > 10)
        {
            StopCoroutine(NextPoint());
            transform.position = Vector3.MoveTowards(transform.position, homePoint, step);
            Vector3 newHDir = Vector3.RotateTowards(transform.forward, homePoint - transform.position, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newHDir);
            StartCoroutine(SpawnPoint());
        }


    }

    IEnumerator NextPoint()
    {
        // Send the birds to a different point
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
            int rand = Random.Range(0, target.Length);
            point = target[rand].position;
            birdPoints += 1;
        }
    }

    IEnumerator SpawnPoint()
    {
        // Return the birds home
        //while (true)
        //{
        yield return new WaitForSeconds(Random.Range(30, 50));
        int homeRand = Random.Range(0, homeTarget.Length);
        homePoint = homeTarget[homeRand].position;
        birdPoints = 0;
        //}
    }
}
