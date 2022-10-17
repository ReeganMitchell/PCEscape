using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public int rayCount = 100;
    public float fov = 90f;
    public float viewDistance = 5f;
    public bool on;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            UpdateMesh();
        } else
        {
            mesh.Clear();
        }
    }

    void UpdateMesh()
    {
        Vector3 origin = transform.position;
        float angle = transform.parent.rotation.eulerAngles.z - 90 - (fov / 2);
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = transform.localPosition;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            float angleRadian = angle * Mathf.Deg2Rad;
            Vector3 vertex;

            RaycastHit2D rayHit = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angleRadian), Mathf.Sin(angleRadian)), viewDistance);
            if (rayHit)
            {
                vertex = rayHit.point;
            }
            else
            {
                vertex = origin + new Vector3(Mathf.Cos(angleRadian), Mathf.Sin(angleRadian)) * viewDistance;
            }

            vertices[vertexIndex] = vertex - origin;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle += angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.triangles = mesh.triangles.Reverse().ToArray();

        transform.rotation = Quaternion.identity;
    }
}
