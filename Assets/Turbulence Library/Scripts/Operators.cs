using UnityEngine;
using System.Collections;

public class Operators : MonoBehaviour 
{
	private NoiseManager nm;
	Texture2D heightmap;
	private GameObject renderPlane1;
    private GameObject renderPlane2;
    private GameObject renderPlane3;
    private GameObject renderPlane4;
	
	private Material perlinStandard;
	private Material perlinRidged;
	private Material voronoi;

    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;

    public Texture texture1;
    public Texture texture2;

	// Use this for initialization
	void Start () 
    {
		nm = this.GetComponent<NoiseManager>();
		
		renderPlane1 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane1.transform.localPosition = new Vector3(-5, 0, 5);
        renderPlane1.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        renderPlane2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane2.transform.localPosition = new Vector3(5, 0, 5);
        renderPlane2.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        renderPlane3 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane3.transform.localPosition = new Vector3(5, 0, -5);
        renderPlane3.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        renderPlane4 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane4.transform.localPosition = new Vector3(-5, 0, -5);
        renderPlane4.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetButtonDown("Fire1"))
		{
			Operation();
		}
	}
	
	void Operation()
	{
		// Create some noises
		perlinStandard = nm.CreateNoise(NoiseTypes.PerlinStandard);
		voronoi = nm.CreateNoise(NoiseTypes.MultiVoronoi);
		perlinRidged = nm.CreateNoise(NoiseTypes.PerlinRidged);

		// Combine noises and output result to a plane
        
        mat2 = nm.Min(perlinStandard, voronoi);
        mat3 = perlinStandard;

        renderPlane1.GetComponent<MeshRenderer>().material = mat1;
        renderPlane2.GetComponent<MeshRenderer>().material = mat2;
        renderPlane3.GetComponent<MeshRenderer>().material = mat3;
	}
}
