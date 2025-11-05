using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    
    public virtual void Move(float input = 1f)
    {
        transform.position += transform.forward * moveSpeed * input * Time.deltaTime;
    }
}