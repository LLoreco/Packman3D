public class NumberData
{
    private float movementSpeed = 25f;
    private float rotationSpeed = 150f;
    public float Speed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }
    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
        set
        {
            rotationSpeed = value;
        }
    }
}
