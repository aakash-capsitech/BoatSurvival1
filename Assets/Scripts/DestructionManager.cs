using System.Collections.Generic;
using UnityEngine;

public class DestructionManager : MonoBehaviour
{
    public float destroyY = -20f;
    public static List<GameObject> trackedObjects = new List<GameObject>();

    void Update()
    {
        for (int i = trackedObjects.Count - 1; i >= 0; i--)
        {
            if (trackedObjects[i] == null)
            {
                trackedObjects.RemoveAt(i);
                continue;
            }

            if (trackedObjects[i].transform.position.y < destroyY)
            {
                Destroy(trackedObjects[i]);
                trackedObjects.RemoveAt(i);
            }
        }
    }
}
