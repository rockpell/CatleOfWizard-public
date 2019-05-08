using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeObjectManager : MonoBehaviour {

    [SerializeField] GameObject practiceObject;
    [SerializeField] Transform[] practiceObjectPoints;
    [SerializeField] Vector3 offsetPracticObjectPoint;
	// Use this for initialization
	void Start () {
        CreatePracticeObjects();
    }

    private void CreatePracticeObjects()
    {
        for(int i = 0; i < practiceObjectPoints.Length; i++)
        {
            CreatePracticeObject(i);
        }
    }

    private void CreatePracticeObject(int positionId)
    {
        GameObject _object = Instantiate(practiceObject, practiceObjectPoints[positionId].position + offsetPracticObjectPoint, new Quaternion(0, 180, 0, 0), this.transform);
        _object.GetComponent<PracticeObject>().PositionId = positionId;
    }

    public void DeadPracticeObject(int positionId)
    {
        StartCoroutine(DelayCreate(positionId));
    }

    private IEnumerator DelayCreate(int positionId)
    {
        yield return new WaitForSeconds(2f);
        CreatePracticeObject(positionId);
    }
}
