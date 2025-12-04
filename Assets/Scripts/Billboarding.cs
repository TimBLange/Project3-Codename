using UnityEngine;

public class Billboarding : MonoBehaviour
{
    [SerializeField] private BillboardType billboardType;
    
    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;
    
    private Vector3 originalRotation;
    public enum BillboardType
    {
        LookAtCamera,
        CameraForward
    };

    private void Awake()
    {
        originalRotation = transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:
                transform.LookAt(Camera.main.transform.position, Vector3.up);
                break;
            case BillboardType.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            default:
                break;
        }
        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX)
        {
            rotation.x = originalRotation.x;
        }
        if (lockY)
        {
            rotation.x = originalRotation.y;
        }
        if (lockZ)
        {
            rotation.x = originalRotation.z;
        }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
