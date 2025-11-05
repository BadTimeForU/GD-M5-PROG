using UnityEngine;

public class ShootFromCameraa : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Plane floor;

    void Start()
    {
        floor = new Plane(Vector3.up, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float dist;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (floor.Raycast(ray, out dist))
            {
                GameObject p = Instantiate(projectilePrefab, transform.position, transform.rotation);
                Vector3 pos = ray.GetPoint(dist);
                p.transform.LookAt(pos);
                p.AddComponent<MoveProj>();
                Destroy(p, 5f);
            }
        }
    }
}