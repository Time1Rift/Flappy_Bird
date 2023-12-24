using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset = 1;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _xOffset + _bird.transform.position.x;
        transform.position = position;
    }
}