using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    Vector2 startingCoords;
    Vector2 mouseOffset;

    public float maxOffset;

    private float theta;
    private float off;

    bool isClicked = false;

	// Use this for initialization
	void Start () {

        startingCoords = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isClicked)
        {
            Vector2 p = startingCoords + (Vector2)(Input.mousePosition) - mouseOffset;

            if (Vector2.Distance(startingCoords, p) < maxOffset)
            {
                transform.position = p;
                off = Vector2.Distance(startingCoords, p) / maxOffset;
            } else {

                off = 1.0f;
                if (startingCoords.x == p.x)
                {

                    if (startingCoords.y > p.y)
                    {
                        theta = Mathf.PI * 3 / 2;

                    } else
                    {
                        theta = Mathf.PI * 1 / 2;
                    }

                } else
                {
                    theta = Mathf.Atan((startingCoords.y - p.y) / (startingCoords.x - p.x));

                }
                
                Vector2 offset = new Vector2 (maxOffset * Mathf.Cos(theta), maxOffset * Mathf.Sin(theta));

                if (p.x < startingCoords.x)
                {
                    offset.x *= -1;
                    offset.y *= -1;

                    if (p.y > startingCoords.y)
                    {
                        theta += Mathf.PI;
                    } else
                    {
                        theta -= Mathf.PI;
                    }
                }

                transform.position = startingCoords + offset;
            }
        }

	}

    public void OnPointerDown(PointerEventData e)
    {
        isClicked = true;
        mouseOffset = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData e)
    {
        isClicked = false;
        transform.position = startingCoords;
        off = 0;
    }

    public float getAngle()
    {
        Debug.Log(theta);
        return theta;
    }
    public float getOffset()
    {
        return off;
    }

}
