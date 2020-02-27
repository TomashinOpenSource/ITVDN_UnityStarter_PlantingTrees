using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    int _appleCounter = 0;
    public Text AppleCounter;
    public int TreePrice = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject == null)
                    return;
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name.Contains("Apple"))
                {
                    _appleCounter++;
                    AppleCounter.text = _appleCounter.ToString();
                    Destroy(hit.collider.gameObject);
                }

                if (hit.collider.gameObject.name.Contains("Floor") && _appleCounter >= TreePrice)
                {
                    _appleCounter -= TreePrice;
                    Vector3 pointPosition = hit.point;
                    GameObject tree = Instantiate(Resources.Load("Tree"), pointPosition, Quaternion.identity) as GameObject;
                }
            }
        }

        }
}
