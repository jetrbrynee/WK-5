using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class QuadraticCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform controlPoint;
    public Transform endPoint;
    public int numberOfPoints = 50;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;

        CalculateQuadraticCurvePoints();
        UpdateLineRenderer();
    }

    private void CalculateQuadraticCurvePoints()
    {
        Vector3[] points = new Vector3[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float t = i / (float)(numberOfPoints - 1);
            points[i] = CalculateQuadraticPoint(t);
        }

        lineRenderer.SetPositions(points);
    }

    private Vector3 CalculateQuadraticPoint(float t)
    {
        float u = 1 - t;
        float tt = Mathf.Pow(t, 2);
        float uu = Mathf.Pow(u, 2);

        Vector3 point = uu * startPoint.position +
                        2 * u * t * controlPoint.position +
                        tt * endPoint.position;

        return point;
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = numberOfPoints;
    }
}
