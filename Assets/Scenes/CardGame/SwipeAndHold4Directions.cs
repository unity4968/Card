using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAndHold4Directions : MonoBehaviour
{
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Manager m_Manager;
    private void Start()
    {
        m_Manager = transform.parent.GetComponent<Manager>();
    }
    public void OnMouseDown()
    {
        //save began touch 2d point
        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    private void OnMouseUp()
    {
        //save ended touch 2d point
        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //create vector from the two points
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

        //normalize the 2d vector
        currentSwipe.Normalize();


        //swipe upwards
        if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            if (Check(transform.localPosition + Vector3.up))
            {
                transform.localPosition = transform.localPosition + Vector3.up;
                Debug.Log("Name:" + gameObject.name);
                Debug.Log("up swipe");
                m_Manager.Syncevalue();
            }
            else
            {
                //transform.position = transform.position + Vector3.up;
                Debug.Log("Else Name:" + gameObject.name + "Pos:" + transform.position + Vector3.up);
            }
        }

        if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            Debug.Log("down swipe");
            if (Check(transform.localPosition + Vector3.down))
            {
                transform.localPosition = transform.localPosition + Vector3.down;
                m_Manager.Syncevalue();
            }

        }
        //swipe left
        if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            Debug.Log("left swipe");
            if (Check(transform.localPosition + Vector3.left))
            {
                transform.localPosition = transform.localPosition + Vector3.left;
                m_Manager.Syncevalue();
            }
        }
        //swipe right
        if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            if (Check(transform.localPosition + Vector3.right))
            {
                transform.localPosition = transform.position + Vector3.right;
                m_Manager.Syncevalue();
            }
        }
    }
    public bool Check(Vector3 Pos)
    {
        var a = m_Manager.Pos.Find(x => x == Pos);
        var checkexist = m_Manager.Pos.Exists(x => x == Pos);
        if (checkexist)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}