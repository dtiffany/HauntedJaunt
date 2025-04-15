using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Header("Ghost Setup")]
    public Transform ghost; // Ghost that will affect the bag's color
    public Renderer bagRenderer;

    [Header("Color Settings")]
    public Color farColor = Color.yellow; // The color when far from the ghost
    public Color closeColor = Color.green; // The color when close to the ghost

    [Header("Distance Settings")]
    public float minDistance = 2f; // Minimum distance for full color change
    public float maxDistance = 10f; // Maximum distance for full color change

    [Header("Smoothing")]
    public float smoothSpeed = 2f; // Smooth speed for color transition

    private Material _bagMaterial;

    void Start()
    {
        if (bagRenderer == null) 
        {
            // Try to find the bag renderer
            var foundBag = GameObject.Find("Bag"); // Name of your bag object in the scene
            if (foundBag != null)
            {
                bagRenderer = foundBag.GetComponent<Renderer>();
            }
        
            if (bagRenderer == null)
            {
                Debug.LogError("Could not find Renderer on Bag!");
                return;
            }
        }

        if (bagRenderer.material == null)
        {
            Debug.LogError("Bag Renderer has no material assigned");
            return;
        }
        
        // Create new material instance to ensure we can modify it
        _bagMaterial = new Material(bagRenderer.material);
        bagRenderer.material = _bagMaterial;
        
        Debug.Log("Created new material instance for color changes");
    }

    void Update()
    {
        if (_bagMaterial == null || ghost == null) return;

        // Get the distance between the bag and the ghost
        float distance = Vector3.Distance(transform.position, ghost.position);

        // Use Mathf.InverseLerp to get a normalized value (0 to 1) based on the distance
        float t = Mathf.InverseLerp(maxDistance, minDistance, distance);

        // Interpolate between farColor (yellow) and closeColor (green)
        Color targetColor = Color.Lerp(farColor, closeColor, t);

        // Smoothly interpolate the material's color toward the target color
        _bagMaterial.SetColor("_BaseColor", Color.Lerp(_bagMaterial.GetColor("_BaseColor"), targetColor, Time.deltaTime * smoothSpeed));

        // Debugging
        Debug.Log($"Distance to ghost: {distance:F2}, t: {t:F2}, Target Color: {targetColor}");
    }
}
