using System;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool IsFull = false;
    public bool isNameEquals;

    public Transform objectCube;
    public Transform objectCubeParent;
    public Rigidbody objectCubeParentRig;
    private Collider objectCubeCol;

    public event Action<string, TriggerScript> onTriggerEnter;
    public event Action onTriggerExit;

    public Collider triggerCollider;
    void Start()
    {
        triggerCollider = GetComponent<Collider>();
    }

    private void CheakName()
    {
        if (objectCube.name == transform.name && objectCube.position == transform.position)
        {
            Debug.Log("Имя совпало");
            isNameEquals = true;
            onTriggerEnter?.Invoke(objectCube.name, this);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (IsFull == false)
        {
            Debug.Log("Зашел");
            MoveSetToTrigger(other);
            IsFull = true;

            objectCubeParentRig = objectCubeParent.GetComponent<Rigidbody>();

            objectCubeCol = objectCube.GetComponent<Collider>();
            //objectCubeCol.isTrigger = true;
            objectCubeParentRig.isKinematic = true;

            CheakName();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectCubeParentRig.isKinematic == true)
        {

            Debug.Log("Вышел");
            IsFull = false;
            objectCubeParentRig.isKinematic = false;
            onTriggerExit?.Invoke();
            isNameEquals = false;
        }


        //objectCubeCol.isTrigger = false;
        //objectCube = null;
        // objectCubeParent = null;

    }

    private void MoveSetToTrigger(Collider other)
    {
        objectCube = other.transform;
        objectCubeParent = objectCube.parent;
        var distanceBetween = objectCube.position - transform.position;
        objectCubeParent.transform.position -= distanceBetween;
        objectCubeParent.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
