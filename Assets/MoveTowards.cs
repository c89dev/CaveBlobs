using UnityEngine;

public class MoveTowardsExample : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    public bool hasLoot = false;

    // The caveTarget (cylinder) position.
    public Transform caveTarget;
    public Transform chestTarget;
    public Transform idleTarget;
    public Transform restTarget;
    private Transform _currentTarget;
    

    void Awake()
    {

        _currentTarget = caveTarget;
    }

    void Update()
    {
        // Move our position a step closer to the caveTarget.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.001f)
        {
            if (hasLoot)
            {
                _currentTarget = chestTarget;
                
            }
            else{_currentTarget = idleTarget;}
            // Reset the caveTarget position to the original object position.
            // caveTarget.position *= -1.0f;
        }
    }
}
