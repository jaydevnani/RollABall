using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] points;
    public int point_no = 0;
    public float tolerance;
    public float speed;
    public float delay_time;

    private Vector3 current;
    private float delay_start;

    public bool automatic;
    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != current)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
    Vector3 heading = current - transform.position;
    transform.position += (heading/heading.magnitude) * speed* Time.deltaTime;
        if(heading.magnitude<tolerance)
        {
            transform.position = current;
            delay_start = Time.time;
        }
    }

    void UpdateTarget()
    {
        if(automatic)
        {
            if(Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        point_no++;
        if(point_no >= points.Length)
        {
            point_no = 0;
        }
        current = points[point_no];
    }
}