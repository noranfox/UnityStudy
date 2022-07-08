using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCotroller : MonoBehaviour
{
    public Transform target;        // 따라다닐 타겟 오브젝트의 Transform

    private Transform tr;                // 카메라 자신의 Transform
    public float X = 0.82f;
    public float Y = 0.0f;
    public float Z = 6.56f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        tr.position = new Vector3(target.position.x - X, target.position.y-Y, target.position.z - Z);

        tr.LookAt(target);
    }
}
