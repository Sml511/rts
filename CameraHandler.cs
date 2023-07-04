using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;


    private float orthographicSize;
    private float targetOrthographicSize;





    private void Start()
    {


        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;

    }


    private void Update()
    {

        HandleMovement();
        HandleZoom();


    }

    private void HandleMovement()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector3 moveDir = new Vector3(x,y).normalized;

        float moveSpeed = 10f;

        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;

       

    }

   
    private void HandleZoom()
    {


        float zoomAmount = 1f;
        targetOrthographicSize += Input.mouseScrollDelta.y * zoomAmount;

        float minOrthograpbicSize = 10;
        float maxOrthographicSize = 30;

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize,minOrthograpbicSize,maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize,targetOrthographicSize,Time.deltaTime*zoomSpeed);


        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;





    }

   




}
