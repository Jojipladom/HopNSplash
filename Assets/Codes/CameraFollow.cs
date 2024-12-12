using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance; 

    [SerializeField] private Transform playerTransform;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SomeStaticMethod()
    {
        if (Instance != null)
        {
            Instance.playerTransform.position = new Vector3(0, 0, 0);
        }
    }

    public void UpdatePlayerPosition(Vector3 newPosition)
    {
        if (playerTransform != null)
        {
            playerTransform.position = newPosition;
        }
    }

    void LateUpdate()
    {

        if (playerTransform == null)
        {

            return;
        }


        Vector3 desiredPosition = playerTransform.position + new Vector3(0, 0, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
    }
}

