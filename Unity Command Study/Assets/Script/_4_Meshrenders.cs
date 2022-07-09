using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _4_Meshrenders : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {  //color( R,G,B)
            mat.color = new Color(0, 0, 0); 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {  //color( R,G,B)
            mat.color = new Color(1,  0, 0);
        }
    }


    private void OnTriggerStay(Collider other) //����� cube���� �̸� Collider���� triger�� ���ش�.
    {
        if (other.name == "Cube")
        {
          //  mat.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }

}
