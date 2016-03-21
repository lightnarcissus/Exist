function Update () { 
	renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, 200f, Input.mousePosition.x)); 
}