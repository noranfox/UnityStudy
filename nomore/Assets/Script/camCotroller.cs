using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCotroller : MonoBehaviour
{
    public Transform target;        // ����ٴ� Ÿ�� ������Ʈ�� Transform

    private Transform tr;                // ī�޶� �ڽ��� Transform
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
