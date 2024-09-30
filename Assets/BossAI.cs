using UnityEngine;
using System.Collections;
public class BossAI : MonoBehaviour
{
    public float speed = 4.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;
    [SerializeField] private GameObject canonPrefab;
    private GameObject _canon;

    private void Start()
    {
        _alive = true;
    }
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_canon == null)
                    {
                        _canon = Instantiate(canonPrefab) as GameObject;
                        _canon.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _canon.transform.rotation = transform.rotation;
                    }
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    public void setAlive(bool alive)
    {
        _alive = alive;
    }

}