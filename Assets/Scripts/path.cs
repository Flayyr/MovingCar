using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {
    public Transform[] points;
    private int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    private void Start() {

    }

    private void Update() {
        if(currentWayPoint < this.points.Length) {
            if(targetWayPoint == null) {
                targetWayPoint = points[currentWayPoint];
            }
            drive();
        }
    }

    private void drive() {
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
        if(transform.position == targetWayPoint.position) {
            currentWayPoint++;
            if(currentWayPoint < this.points.Length) {
                targetWayPoint = points[currentWayPoint];
            }
        }
    }
}
