using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FocusOnItem : MonoBehaviour
{
    /*Can written more efficient. At a free time add event system and delete update.*/
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Vector3 playerFaceLocation;
    private Coroutine _examine;

    private void Update()
    {
        if (playerHandSo.CurrentObject == null) return;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerHandSo.CurrentObject.transform.position =
                playerHandSo.playerCameraTransform.position + playerHandSo.playerCameraTransform.forward/2;
            playerMovement.enabled = false;
            _examine = StartCoroutine(Examine());
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerHandSo.CurrentObject.transform.position = playerHandSo.playerHandTransform.position;
            playerHandSo.CurrentObject.transform.rotation = playerHandSo.playerHandTransform.rotation;
            playerMovement.enabled = true;
            StopCoroutine(_examine);
        }
    }

    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float rotationX;
    [SerializeField] private float rotationY;

    private IEnumerator Examine()
    {
        while (true)
        {
            rotationY += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX += -Input.GetAxis("Mouse X") * lookSpeed;
            playerHandSo.CurrentObject.transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}