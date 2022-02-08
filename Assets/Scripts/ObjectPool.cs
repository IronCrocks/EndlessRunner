using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] templates)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var templateIndex = Random.Range(0, templates.Length);
            var spawned = Instantiate(templates[templateIndex], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.Find(p => p.activeSelf == false);

        return result != null;
    }
}
