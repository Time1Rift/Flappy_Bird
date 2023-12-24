using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capasity;

    private Camera _camera;
    private List<GameObject> _pool = new();

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }

    protected void Initializ(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capasity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(item => item.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in _pool)
            if (item.activeSelf && item.transform.position.x < disablePoint.x)
                item.SetActive(false);
    }
}