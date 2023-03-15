using UnityEngine;

public class WaypointsRight : MonoBehaviour
{
    public static Transform[] pointsRight;

    void Awake()
    {
        pointsRight = new Transform[transform.childCount];
        for (int i = 0; i < pointsRight.Length; i++)
        {
            pointsRight[i] = transform.GetChild(i);
        }
    }
}
