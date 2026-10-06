using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private KeyCode pickKey = KeyCode.E;
    [SerializeField] private KeyCode dropKey = KeyCode.Q;

    private GameObject currentItem = null;
    private GameObject nearbyItem = null;

    public GoalZone currentGoalZone = null;

    void OnTriggerEnter(Collider other)
    {
        // Detectar item cerca
        if (other.CompareTag("Item") && currentItem == null)
            nearbyItem = other.gameObject;

        // Detectar si entramos al radio de la meta
        GoalZone zone = other.GetComponent<GoalZone>();
        if (zone!= null)
            currentGoalZone = zone;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == nearbyItem)
            nearbyItem = null;

        GoalZone zone = other.GetComponent<GoalZone>();
        if (zone!= null && zone == currentGoalZone)
            currentGoalZone = null;
    }

    void Update()
    {
        // Agarrar item
        if (nearbyItem!= null && currentItem == null && Input.GetKeyDown(pickKey))
        {
            Pick(nearbyItem);
            nearbyItem = null;
        }

        // Soltar item
        if (currentItem!= null && Input.GetKeyDown(dropKey))
        {
            if (currentGoalZone!= null)
            {
                //Dentro del radio GoalZone
                currentGoalZone.DeliverItem(currentItem, this);
            }
            else
            {
                Drop();
            }
        }
    }

    private void Pick(GameObject item)
    {
        currentItem = item;
        Rigidbody rb = item.GetComponent<Rigidbody>();
        Collider col = item.GetComponent<Collider>();

        if (rb!= null) rb.isKinematic = true;
        if (col!= null) col.enabled = false;

        item.transform.SetParent(hand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }

    public void Drop()
    {
        if (currentItem == null) return;

        currentItem.transform.SetParent(null);
        Rigidbody rb = currentItem.GetComponent<Rigidbody>();
        Collider col = currentItem.GetComponent<Collider>();

        if (col!= null) col.enabled = true;
        if (rb!= null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        }
        currentItem = null;
    }
}