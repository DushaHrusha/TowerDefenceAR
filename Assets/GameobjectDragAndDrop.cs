using UnityEngine;

public class GameobjectDragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    private GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
    Rigidbody parentRig;
    void Update()
    {
        
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;
            try{
                 target = GetClickedObject(out hitInfo);
            }
            catch
            {
                UnityEngine.Debug.Log("fsdfsdf");
            }
            //parentRig.isKinematic = false;
            if (target != null)
            {
                _mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
           // parentRig.isKinematic = false;
            //parentRig = null;
            _mouseState = false;
        }

        if (Input.GetKey(KeyCode.H))
        {
            Vector3 rotate = target.transform.eulerAngles;
            rotate.x = 0;
            target.transform.rotation = Quaternion.Euler(rotate);
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 rotate = target.transform.eulerAngles;
            rotate.x = 180;
            target.transform.rotation = Quaternion.Euler(rotate);
        }
        if (Input.GetKey(KeyCode.T))
        {
            Vector3 rotate = target.transform.eulerAngles;
            rotate.z = 0;
            target.transform.rotation = Quaternion.Euler(rotate);
        }
        if (Input.GetKey(KeyCode.G))
        {
            Vector3 rotate = target.transform.eulerAngles;
            rotate.z = 180;
            target.transform.rotation = Quaternion.Euler(rotate);
        }


        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            target.transform.position = curPosition;
        }
    }


    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        Transform parent;
        if (!target.transform.parent && target.transform.parent.tag == "Player")
            parent = target.transform;
        else
            parent = target.transform.parent;
        
        //parentRig = parent.GetComponent<Rigidbody>();
        // parentRig.isKinematic = false;
        return parent.gameObject;
    }
}
