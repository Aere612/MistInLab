using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] protected  GameObject objectToSpawn;
    [SerializeField] protected PlayerHandSo _playerHandSo;

    public void Interaction()
    {            
        Debug.Log("Girdi1");

        if (_playerHandSo.CurrentObject == null)
        {
            Debug.Log("Girdi2");
            var instantiatedObject = Instantiate(objectToSpawn);
            _playerHandSo.PutObjectToHand(instantiatedObject);
        }
    }
}