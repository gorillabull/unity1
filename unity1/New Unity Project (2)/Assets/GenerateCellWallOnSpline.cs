using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCellWallOnSpline : MonoBehaviour
{
    public BezierSpline spline;
    public float duration; //interval
    private float progress =0;
    public GameObject cellWallPart;
    List<GameObject> walls;
    // Start is called before the first frame update
    void Start()
    {
        walls = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progress<1)
        {
            Debug.Log(progress);
            progress += Time.deltaTime / duration;
            Quaternion q = new Quaternion();
            q.SetLookRotation(spline.GetVelocity(progress));

            if (progress > 1f)
            {
                progress = 1f;
            }
            Vector3 pos = spline.GetPoint(progress);
            pos.z = 0;
            GameObject b = Instantiate(cellWallPart, pos
                 , this.transform.rotation);
            b.SetActive(true);
            walls.Add(b);
        }
    }

    /// <summary>
    /// Not used
    /// </summary>
    void GenerateCellWall()
    {
        if (progress<1)
        {
            progress += Time.deltaTime / duration;
            Debug.Log(progress);
            Quaternion q = new Quaternion();
            q.SetLookRotation(spline.GetVelocity(progress));

            if (progress > 1f)
            {
                progress = 1f;
            }
            walls.Add(Instantiate(cellWallPart, spline.GetPoint(progress)
                , this.transform.rotation));

        }



    }
}
