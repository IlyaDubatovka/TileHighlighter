
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    private const string WATER = "Water";
    private Color _previousColor ;
    private Renderer _previousRenderer;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)&&_previousRenderer==null)
        {
            _previousRenderer=hitInfo.transform.GetComponent<Renderer>();
            if (_previousRenderer.CompareTag(WATER))
            {
                return;
            }
            _previousColor = _previousRenderer.material.color;
            _previousRenderer.material.color=Color.cyan;
        }
        else if (!Physics.Raycast(ray, out hitInfo)&&_previousRenderer!=null)
        {
            _previousRenderer.material.color = _previousColor;
            _previousRenderer = null;
            Debug.Log("",_previousRenderer);
        }
        else if (Physics.Raycast(ray, out hitInfo)&&_previousRenderer!=null)
        {
            Renderer newRenderer = hitInfo.transform.GetComponent<Renderer>();
            if (newRenderer!=_previousRenderer&&!newRenderer.CompareTag(WATER))
            {
                _previousRenderer.material.color = _previousColor;
                newRenderer.material.color = Color.cyan;
                _previousRenderer = newRenderer;
            }
        }


    }
}
