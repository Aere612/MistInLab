using System;
using UnityEngine;
using DG.Tweening;

public class S_Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool doorClosed = true;
    [SerializeField] private bool isLocked = true;
    [SerializeField] private Transform pivot;
    [SerializeField] private Rigidbody lockRb1;
    [SerializeField] private Rigidbody lockRb2;
    [SerializeField] private Trash lockTrash1;
    [SerializeField] private Trash lockTrash2;
    [SerializeField] private PlayerHandSo playerHandSo;

    private void Awake()
    {
        lockTrash1.IsAvaibleToCollect = false;
        lockTrash2.IsAvaibleToCollect = false;
    }

    public void Interaction()
    {
        if (isLocked)
        {
            if (playerHandSo.CurrentObject == null) return;
            if (playerHandSo.CurrentObject.TryGetComponent(out Vial vial) && 
                vial.baseIngradiant == Ingradiant.Green)
            {
                isLocked = false;
                lockTrash1.IsAvaibleToCollect = true;
                lockTrash2.IsAvaibleToCollect = true;
                lockRb1.isKinematic = false;
                lockRb2.isKinematic = false;
            }
            return;
        }

        if (doorClosed)
        {
            doorClosed = false;
            pivot.DORotate(new Vector3(0, -90, 0f), 0.5f);
            return;
        }

        doorClosed = true;
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f);
    }
}