using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSlot : BaseObjectSlot
{
    [SerializeField] private bool placeReverse;
    [SerializeField] private bool placeHorizontal;
    [SerializeField] private AudioSource paperSfx;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Paper>(out var paper) || _currentObject != null) return;
        paperSfx.Play();
        _currentObject = paper;
        PlaceTheObject(_currentObject.gameObject,placeReverse,placeHorizontal);
        _currentObject._objectSlot = this;
    }

    public Paper CurrentObject
    {
        get => (Paper)_currentObject;
        set => _currentObject = value;
    } 
}
