using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    public enum Direction {x,y,z,code};
    public Direction direction = Direction.y;
    public float RotationsPerMinute = 10;
    public bool isUI = false;
    private RectTransform rt;

    private void Start()
    {
        if (isUI)
        {
            rt = gameObject.GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if (isUI == false)
        {
            switch (direction)
            {
                case Direction.x:
                    transform.Rotate(6.0f * RotationsPerMinute * Time.deltaTime, 0, 0);
                    break;
                case Direction.y:
                    transform.Rotate(0, 6.0f * RotationsPerMinute * Time.deltaTime, 0);
                    break;
                case Direction.z:
                    transform.Rotate(0, 0, 6.0f * RotationsPerMinute * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case Direction.x:
                    rt.Rotate(6.0f * RotationsPerMinute * Time.deltaTime, 0, 0);
                    break;
                case Direction.y:
                    rt.Rotate(0, 6.0f * RotationsPerMinute * Time.deltaTime, 0);
                    break;
                case Direction.z:
                    rt.Rotate(0, 0, 6.0f * RotationsPerMinute * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }

        
    }
}
