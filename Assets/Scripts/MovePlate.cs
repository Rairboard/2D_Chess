using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX, matrixY;

    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if(attack )
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }
        int tmpX = reference.GetComponent<Chessman>().GetXBoard();
        int tmpY = reference.GetComponent<Chessman>().GetYBoard();

        controller.GetComponent<Game>().SetPositionEmpty(tmpX, tmpY);

        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        reference.GetComponent<Chessman>().DestroyMovePlates();
    }
    public void SetCoords(int x,int y)
    {
        matrixX = x;
        matrixY = y;
    }
    public void SetReference(GameObject obj)
    {
        reference = obj;
    }
    public GameObject GetReference() {  return reference; }
}
