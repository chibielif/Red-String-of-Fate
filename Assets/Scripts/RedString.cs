using UnityEngine;

public class RedString : MonoBehaviour
{
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    public Vector3[] segmentVelocities;

    public Transform targetDir;
    public float targetDistance;
    public float smoothSpeed;
    public float trailSpeed;

    public Transform startDir;
    
    void Start()
    {
        lineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVelocities = new Vector3[length];
    }

    
    void Update()
    {
        //length = Mathf.FloorToInt(Mathf.Abs(targetDir.localPosition.x - startDir.localPosition.x)) * 2;

        segmentPoses[0] = targetDir.position;
        segmentPoses[length - 1] = startDir.position;

        for (int i = 1; i < segmentPoses.Length - 1; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDistance,
                ref segmentVelocities[i],  smoothSpeed + i / trailSpeed);
        }
        lineRenderer.SetPositions(segmentPoses);
    }
}
