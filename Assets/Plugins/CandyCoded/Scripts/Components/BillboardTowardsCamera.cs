using UnityEngine;

public class BillboardTowardsCamera : MonoBehaviour
{

    [SerializeField]
    private Transform mainCamera;

    private void Awake()
    {

        if (mainCamera == null)
        {

            mainCamera = Camera.main.transform;

        }

    }

    private void Update()
    {

        gameObject.transform.LookAt(gameObject.transform.position + mainCamera.rotation * Vector3.forward);

    }

}
