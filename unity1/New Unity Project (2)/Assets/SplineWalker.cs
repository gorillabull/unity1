using UnityEngine;

public class SplineWalker : MonoBehaviour
{

    public BezierSpline spline;

    public float duration;

    private float progress;

    private void Update()
    {
        progress += Time.deltaTime / duration;
        if (progress > 1f)
        {
            progress = 0f;
        }
        transform.localPosition = spline.GetPoint(progress);
    }
}