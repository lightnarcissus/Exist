using UnityEngine;
using System.Collections;
using System.Collections.Generic;

static class Constants
{
    public const int NB_MAT_CG = 30;
    public const int NB_TYPES = 8;
    public const int NB_CG_VORONOI = 2;
    public const int NB_GLSL_VORONOI = 7;
    public const int NB_GLSL_VORONOI_IMPL1 = 10;
    public const int NB_GLSL_VORONOI_IMPL2 = 9;
    public const int NB_HERMITE = 3;
    public const int NB_PERLIN = 3;
    public const int NB_SIMPLEX = 3;
    public const int NB_ADV_HERMITE = 4;
    public const int NB_ADV_PERLIN = 4;
    public const int NB_ADV_SIMPLEX = 4;
    public const int NB_OTHER = 7;
    public const int NB_MAT_GLSL = 92;
    public const int NB_TEX = 15;
	
	public const int nbCombiner = 5;
	public const int nbModifier = 7;
	public const int nbSelector = 2;
	public const int nbTransformer = 6;
}

static class NoiseTypes
{
	public const string MultiVoronoi = "Voronoi/MultiVoronoi";
	public const string SimplexF1 = "Voronoi/SimplexF1";
	public const string PerlinStandard = "Perlin/Standard";
	public const string PerlinBillowed = "Perlin/Billowed";
	public const string PerlinRidged = "Perlin/Ridged";
    public const string PerlinJordan = "Advanced Perlin/Jordan";
    public const string PerlinIQ = "Advanced Perlin/IQ";
    public const string PerlinSwiss = "Advanced Perlin/Swiss";
    public const string PerlinBadlands = "Advanced Perlin/Badlands";
    public const string HermiteStandard = "Hermite/Standard";
    public const string HermiteBillowed = "Hermite/Billowed";
    public const string HermiteRidged = "Hermite/Ridged";
    public const string HermiteJordan = "Advanced Hermite/Jordan";
    public const string HermiteIQ = "Advanced Hermite/IQ";
    public const string HermiteSwiss = "Advanced Hermite/Swiss";
    public const string HermiteBadlands = "Advanced Hermite/Badlands";
    public const string SimplexStandard = "Simplex/Standard";
    public const string SimplexBillowed = "Simplex/Billowed";
    public const string SimplexRidged = "Simplex/Ridged";
    public const string SimplexJordan = "Advanced Simplex/Jordan";
    public const string SimplexIQ = "Advanced Simplex/IQ";
    public const string SimplexSwiss = "Advanced Simplex/Swiss";
    public const string SimplexBadlands = "Advanced Simplex/Badlands";
    public const string Cubist = "Other/Cubist";
    public const string PolkaDot = "Other/PolkaDot";
    public const string PolkaSquare = "Other/PolkaSquare";
    public const string SimplexPolkaDot = "Other/SimplexPolkaDot";
    public const string SparseConvolution = "Other/SparseConvolution";
    public const string Stars = "Other/Stars";
    public const string Value = "Other/Value";
}
static class CombinerTypes
{
	public const string Add = "Add";
	public const string Max = "Max";
	public const string Min = "Min";
	public const string Multiply = "Multiply";
	public const string Power = "Power";
}
static class ModifierTypes
{
	public const string Abs = "Abs";
	public const string Clamp = "Clamp";
	public const string Curve = "Curve";
	public const string Exponent = "Exponent";
	public const string Invert = "Invert";
	public const string ScaleBias = "ScaleBias";
	public const string Terrace = "Terrace";
}
static class SelectorTypes
{
	public const string Blend = "Blend";
	public const string Select = "Select";
}
static class TransformerTypes
{
	public const string Translate = "Translate";
	public const string Rotate = "Rotate";
	public const string Scale = "Scale";
	public const string Colorize = "Colorize";
	public const string Texturize = "Texturize";
	public const string Turbulence = "Turbulence";
}

public class NoiseManager : MonoBehaviour 
{
    public int texWidth = 1024, texHeight = 1024;
    public int rtWidth = 1024, rtHeight = 1024;
    public Texture2D heightmap;
    public RenderTexture heightmapRT;

    void Start()
    {
        heightmapRT = new RenderTexture(rtWidth, rtHeight, 24, RenderTextureFormat.ARGB32);
		heightmapRT.wrapMode = TextureWrapMode.Repeat;
        heightmap = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
		heightmap.wrapMode = TextureWrapMode.Repeat;
    }

    void Update()
    {
        //GetHeightMap2();
    }

	public Material CreateNoise(string noiseType)
	{
		Material mat = new Material(Shader.Find("Noise/CG/" + noiseType));

        return mat;
	}
	
    public Texture2D GetHeightMapTex(Material mat)
    {
		heightmapRT = new RenderTexture(rtWidth, rtHeight, 24, RenderTextureFormat.ARGB32);
        heightmapRT.wrapMode = TextureWrapMode.Repeat;
		heightmap = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
		heightmap.wrapMode = TextureWrapMode.Repeat;
		
        GameObject renderCamera = new GameObject();
        renderCamera.AddComponent<Camera>();
        renderCamera.GetComponent<Camera>().backgroundColor = Color.black;
        renderCamera.GetComponent<Camera>().orthographic = true;
        renderCamera.GetComponent<Camera>().orthographicSize = 5;
        renderCamera.GetComponent<Camera>().transform.localPosition = new Vector3(9999, 10009, 9999);
        renderCamera.GetComponent<Camera>().transform.localRotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

        GameObject renderPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane.transform.localPosition = new Vector3(9999, 9999, 9999);
        renderPlane.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        renderPlane.GetComponent<MeshRenderer>().material = mat;

        RenderTexture.active = heightmapRT;

        renderCamera.GetComponent<Camera>().targetTexture = heightmapRT;
        renderCamera.GetComponent<Camera>().Render();
        heightmap.ReadPixels(new Rect(0.0f, 0.0f, heightmapRT.width, heightmapRT.height), 0, 0);
		heightmap.Apply();
        renderCamera.GetComponent<Camera>().targetTexture = null;
        
        RenderTexture.active = null;
        DestroyImmediate(renderPlane);
        DestroyImmediate(renderCamera);
        RenderTexture.ReleaseTemporary(heightmapRT);
		
		return heightmap;
    }
	
	public Texture GetHeightMapRT(Material mat)
    {
        heightmapRT = new RenderTexture(rtWidth, rtHeight, 24, RenderTextureFormat.ARGB32);
        heightmapRT.wrapMode = TextureWrapMode.Repeat;

        GameObject renderCamera = new GameObject();
        renderCamera.AddComponent<Camera>();
        renderCamera.GetComponent<Camera>().backgroundColor = Color.black;
        renderCamera.GetComponent<Camera>().orthographic = true;
        renderCamera.GetComponent<Camera>().orthographicSize = 5;
        renderCamera.GetComponent<Camera>().transform.localPosition = new Vector3(9999, 10009, 9999);
        renderCamera.GetComponent<Camera>().transform.localRotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

        GameObject renderPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        renderPlane.transform.localPosition = new Vector3(9999, 9999, 9999);
        renderPlane.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        renderPlane.GetComponent<MeshRenderer>().material = mat;

        RenderTexture.active = heightmapRT;

        renderCamera.GetComponent<Camera>().targetTexture = heightmapRT;
        renderCamera.GetComponent<Camera>().Render();
        renderCamera.GetComponent<Camera>().targetTexture = null;
        
        RenderTexture.active = null;
        DestroyImmediate(renderPlane);
        DestroyImmediate(renderCamera);
		
		return heightmapRT;
    }

    public RenderTexture GetHeightMapRT2(Material mat)
    {
        Graphics.Blit(heightmapRT, heightmapRT, mat);

        return heightmapRT;
    }

    //void GetHeightMap2()
    //{
    //    GameObject renderCamera = new GameObject();
    //    renderCamera.AddComponent<Camera>();
    //    renderCamera.camera.backgroundColor = Color.white;
    //    renderCamera.camera.orthographic = true;
    //    renderCamera.camera.orthographicSize = 5;

    //    RenderTexture.active = heightmap;

    //    renderCamera.camera.targetTexture = heightmap;

    //    GL.PushMatrix();
    //    GL.LoadOrtho();
    //    GL.Viewport(new Rect(0, 0, heightmap.width, heightmap.height));

    //    material.SetPass(0);

    //    GL.Begin(GL.QUADS);
    //    GL.TexCoord2(0, 0);
    //    GL.Vertex3(0.0f, 0.0f, 0);
    //    GL.TexCoord2(0, 1);
    //    GL.Vertex3(0.0f, 1.0f, 0);
    //    GL.TexCoord2(1, 1);
    //    GL.Vertex3(1.0f, 1.0f, 0);
    //    GL.TexCoord2(1, 0);
    //    GL.Vertex3(1.0f, 0.0f, 0);
    //    GL.End();
    //    GL.PopMatrix();

    //    // Read pixels
    //    noiseTex.ReadPixels(new Rect(0.0f, 0.0f, heightmap.width, heightmap.height), 0, 0);
    //    noiseTex.Apply();

    //    // Clean up
    //    renderCamera.camera.targetTexture = null;
    //    RenderTexture.active = null;
    //    DestroyImmediate(renderCamera);
    //}

    // Combiners
	public Material Add(Material noise1, Material noise2)
	{
		Material mat = new Material(Shader.Find("Noise/Operator/Add"));
		mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
		mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));
		
		return mat;
	}

    public Material Max(Material noise1, Material noise2)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Max"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));

        return mat;
	}

    public Material Min(Material noise1, Material noise2)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Min"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));

        return mat;
	}

    public Material Multiply(Material noise1, Material noise2)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Multiply"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));

        return mat;
	}

    public Material Power(Material noise1, Material noise2)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Power"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));

        return mat;
	}
	
	// Modifiers
    public Material Abs(Material noise)
    {
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));

        return mat;
    }

    public Material Clamp(Material noise, float lowerBound, float upperBound)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));
        mat.SetFloat("_LowerBound", lowerBound);
        mat.SetFloat("_UpperBound", upperBound);

        return mat;
	}
	
	public Material Curve(Material noise, AnimationCurve curve)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Curve"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));

        return mat;
	}

    public Material Exponent(Material noise, float exp)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));
        mat.SetFloat("_Exponent", exp);

        return mat;
	}
	
	public Material Invert(Material noise, float fullRange)
	{
		Material mat = new Material(Shader.Find("Noise/Operator/Invert"));
		mat.SetTexture("_HeightMap", GetHeightMapRT(noise));
		mat.SetFloat("_FullRange", fullRange);
		
		return mat;
	}

    public Material ScaleBias(Material noise, float scale, float bias)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));
        mat.SetFloat("_Scale", scale);
        mat.SetFloat("_Bias", bias);

        return mat;
	}
	
	public Material Terrace(Material noise)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Terrace"));
        mat.SetTexture("_HeightMap", GetHeightMapRT(noise));

        return mat;
	}

    public Material Blend(Material noise1, Material noise2, Material control)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));
        mat.SetTexture("_ControlMap", GetHeightMapRT(control));

        return mat;
	}

    public Material Select(Material noise1, Material noise2, Material control, float edgeFalloff, float lowerBound, float upperBound)
	{
        Material mat = new Material(Shader.Find("Noise/Operator/Abs"));
        mat.SetTexture("_HeightMap1", GetHeightMapRT(noise1));
        mat.SetTexture("_HeightMap2", GetHeightMapRT(noise2));
        mat.SetTexture("_ControlMap", GetHeightMapRT(control));
        mat.SetFloat("_EdgeFalloff", edgeFalloff);
        mat.SetFloat("_LowerBound", lowerBound);
        mat.SetFloat("_UpperBound", upperBound);

        return mat;
	}

    public Material Turbulence(Material noise, Material mapX, Material mapY, Material mapZ, float power)
	{
        noise.SetTexture("_TurbulenceMapX", GetHeightMapRT(mapX));
        noise.SetTexture("_TurbulenceMapY", GetHeightMapRT(mapY));
        noise.SetTexture("_TurbulenceMapZ", GetHeightMapRT(mapZ));
        noise.SetFloat("_TurbulencePower", power);

        return noise;
	}

    public Material Translate(Material noise, Vector3 move)
	{
        noise.SetVector("_NoiseOffset", move);

        return noise;
	}

    public Material Scale(Material noise, Vector2 scale)
	{
        noise.SetVector("_NoiseScale", scale);

        return noise;
	}

    public Material Rotate(Material noise, Vector3 rotation)
	{
        noise.SetVector("_NoiseRotation", rotation);

        return noise;
	}
}
