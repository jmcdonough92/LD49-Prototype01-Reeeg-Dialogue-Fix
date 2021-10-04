using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private float offset;
    private Vector3[] positions;
    private Vector3 position;
    private float value = 0;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[lr.positionCount];
        lr.GetPositions(positions);
        //StartCoroutine("SetWavePositions");
    }

    // Update is called once per frame
    void Update()
    {
        SetWavePositions();
    }

    void InitializeLine()
    {

    }

    void SetWavePositions()
    {
        
        for (int i = 0; i < lr.positionCount; i++)
        {
            position = lr.GetPosition(i);
            position.y = Mathf.Sin(Time.time + (offset * i));
            lr.SetPosition(i, position);
        }
        value = lr.GetPosition(lr.positionCount / 2).y;
        //yield return new WaitForSeconds(0.2f);
    }

    public float GetValue()
    {
        return value;
    }

    //IEnumerator SetWavePositions()
    //{

    //    for(int i = 0; i<lr.positionCount; i++)
    //    {
    //        position = lr.GetPosition(i);
    //        position.y = Mathf.Sin(Time.time + (offset * i));
    //        lr.SetPosition(i, position);
    //    }
    //    yield return new WaitForSeconds(0.2f);
    //}
    
}
