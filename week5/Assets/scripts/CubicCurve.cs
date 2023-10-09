using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CubicCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform controlPoint1;
    public Transform controlPoint2;
    public Transform endPoint;
    public int numberOfPoints = 50;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;

        CalculateCubicCurvePoints();
        UpdateLineRenderer();
    }

    private void CalculateCubicCurvePoints()
    {
        Vector3[] points = new Vector3[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float t = i / (float)(numberOfPoints - 1);
            points[i] = CalculateCubicPoint(t);
        }

        lineRenderer.SetPositions(points);
    }

    private Vector3 CalculateCubicPoint(float t)
    {
        float u = 1 - t;
        float tt = Mathf.Pow(t, 2);
        float uu = Mathf.Pow(u, 2);
        float ttt = Mathf.Pow(t, 3);
        float uuu = Mathf.Pow(u, 3);

        Vector3 point = uuu * startPoint.position +
                        3 * uu * t * controlPoint1.position +
                        3 * u * tt * controlPoint2.position +
                        ttt * endPoint.position;

        return point;
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = numberOfPoints;
    }
}
