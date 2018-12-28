using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Blacde Trail Effect
/// </summary>
public class MouseControl : MonoBehaviour {


    //line render
    [SerializeField]
    private LineRenderer lineRenderer;

    //whether the first push
    private bool isFirstMouseDown = false;
    //whether mouse is down
    private bool isMouseDown = false;
    // store positions of trail points
    private Vector3[] positions = new Vector3[10];
    //current index of Vector3[]
    private int posCount = 0;
    //the position of the head of the trail 
    private Vector3 head;
    //the mouse position in last frame
    private Vector3 last;
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            isFirstMouseDown = true;
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

        }

        onDrawLine();

        isFirstMouseDown = false;
    }
    // draw line
    private void onDrawLine()
    {
        if (isFirstMouseDown)
        {
            posCount = 0;
            //*******current camera must be tagged as main carema, otherwise will be null******//
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;
        }
        if (isMouseDown)
        {
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if the distance is not too near, then store the position of points
            if (Vector3.Distance(last, head) > 0.1f)
            {
                savePosition(head);
                posCount++;
            }

            last = head;
        }
        else
        {
            //delete all the current points
            positions = new Vector3[10];
        }

        changePosition(positions);
    }

    //change the position of linerender points
    private void changePosition(Vector3[] positions)
    {
        lineRenderer.SetPositions(positions);
    }

    private void savePosition(Vector3 pos)
    {
        //********if doesn't change, the z will be the same with camera.position.z (-12)
        pos.z = 0;
        //if the vector3[] is not full, add position to the following elements 
        if (posCount <= 9)
        {
            for (int i = posCount; i < 10; i++)
            {
                positions[i] = pos;
            }
        }
        else
        //reduce the first element and add posiiton to the end of the Vector3[]
        {
            for (int i = 0; i < 9; i++)
            {
                positions[i] = positions[i+1];
            }
            positions[9] = pos;
        }
    }
}
