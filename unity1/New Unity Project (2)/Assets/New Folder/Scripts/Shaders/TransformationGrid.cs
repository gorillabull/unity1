using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformation : MonoBehaviour
{

    public abstract Vector3 Apply(Vector3 point);
}

 

public class PositionTransformation : Transformation
{

    public Vector3 position;
    public override Vector3 Apply(Vector3 point)
    {
        return point + position;
    }

}

public class ScaleTransformation : Transformation
{

    public Vector3 scale;

    public override Vector3 Apply(Vector3 point)
    {
        point.x *= scale.x;
        point.y *= scale.y;
        point.z *= scale.z;
        return point;
    }
}


public class TransformationGrid : MonoBehaviour
{
    public Transform prefab;

    public int gridResolution = 10;

 
    List<Transformation> transformations;
    Transform[] grid;

    void Awake()
    {
        grid = new Transform[gridResolution * gridResolution * gridResolution];
        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++, i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }

        transformations = new List<Transformation>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponents<Transformation>(transformations);
        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++, i++)
                {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }

    Transform CreateGridPoint(int x, int y, int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / gridResolution,
            (float)y / gridResolution,
            (float)z / gridResolution
        );
        return point;
    }

    Vector3 TransformPoint(int x, int y, int z)
    {
        Vector3 coordinates = GetCoordinates(x, y, z);
        for (int i = 0; i < transformations.Count; i++)
        {
            coordinates = transformations[i].Apply(coordinates);
        }
        return coordinates;
    }

    Vector3 GetCoordinates(int x, int y, int z)
    {
        return new Vector3(
            x - (gridResolution - 1) * 0.5f,
            y - (gridResolution - 1) * 0.5f,
            z - (gridResolution - 1) * 0.5f
        );
    }
}
