using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private RopeRenderer ropeRenderer;
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform ropeStart;
    [SerializeField] private float speed;
    [SerializeField] private PlayerMove playerMove;

    public RopeState currentRopeState;
    private SpringJoint springJoint;
    private float length;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }

        if (currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(ropeStart.transform.position, hook.transform.position);
            if (distance > 20f)
            {
                hook.gameObject.SetActive(false);
                ropeRenderer.Hide();
                currentRopeState = RopeState.Disabled;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentRopeState == RopeState.Active && playerMove.Grounded == false)
            {
                playerMove.Jump();
            }
            Release();
        }

        if (currentRopeState is RopeState.Fly or RopeState.Active)
        {
            ropeRenderer.Draw(ropeStart.position, hook.transform.position, length);
        }
    }

    public void CreateSpring()
    {
        if (springJoint == null)
        {
            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hook.rb;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.anchor = ropeStart.localPosition;
            springJoint.spring = 100;
            springJoint.damper = 5;

            length = Vector3.Distance(ropeStart.position, hook.transform.position);
            springJoint.maxDistance = length;

            currentRopeState = RopeState.Active;
        }
    }

    private void Release()
    {
        if (springJoint)
        {
            Destroy(springJoint);
            currentRopeState = RopeState.Disabled;
            hook.gameObject.SetActive(false);
            ropeRenderer.Hide();
        }
    }

    private void Shot()
    {
        length = 1;
        Destroy(springJoint);
        hook.StopFix();
        hook.transform.position = spawn.position;
        hook.transform.rotation = spawn.rotation;
        hook.rb.velocity = spawn.forward * speed;

        currentRopeState = RopeState.Fly;
        hook.gameObject.SetActive(true);
    }
}