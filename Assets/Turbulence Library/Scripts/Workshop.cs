//
// Turbulence - Massive library of advanced and fast noise on the GPU
// by Jérémie St-Amand - jeremie.stamand@gmail.com
// 

using UnityEngine;
using System.Collections;

public class Workshop : MonoBehaviour
{
    private static string[] NoiseTypes = { "Voronoi", "Hermite", "Perlin", "Simplex", "Advanced Hermite", "Advanced Perlin", "Advanced Simplex", "Other" };
    private static string[] VoronoiNoiseCG = { "MultiVoronoi", "SimplexCellular" };
    private static string[] VoronoiNoiseGLSL = { "Length", "Length2", "Manhattan", "Chebychev", "Quadratic", "Minkowski4", "Minkowski5" };
    private static string[] VoronoiImpl1GLSL = { "F1", "SimplexF1", "F2", "F3", "F4", "Difference21", "Difference32", "Mean12", "Multiplication12", "Crackle" };
    private static string[] VoronoiImpl2GLSL = { "F1", "F2", "F3", "F4", "Difference21", "Difference32", "Mean12", "Multiplication12", "Crackle" };
    private static string[] HermiteNoise = { "Standard", "Billowed", "Ridged" };
    private static string[] PerlinNoise = { "Standard", "Billowed", "Ridged" };
    private static string[] SimplexNoise = { "Standard", "Billowed", "Ridged" };
    private static string[] AdvancedHermiteNoise = { "IQ", "Jordan", "Swiss", "Badlands" };
    private static string[] AdvancedPerlinNoise = { "IQ", "Jordan", "Swiss", "Badlands" };
    private static string[] AdvancedSimplexNoise = { "IQ", "Jordan", "Swiss", "Badlands" };
    private static string[] OtherNoise = { "Value", "Cubist", "PolkaDot", "PolkaSquare", "SimplexPolkaDot", "SparseConvolution", "Stars" };

    /*private static string[] NoiseCG = { "CellularNoise3D", "CubistNoise3D", "PolkaDot3D", "SparseConvolutionNoise3D", "ValueNoise3D",
                                      "HermiteBadlands3D", "HermiteBillowed3D", "HermiteIQ3D", "HermiteJordan3D", "HermiteRidged3D", "HermiteStandard3D", "HermiteSwiss3D",
                                      "PerlinBadlands3D", "PerlinBillowed3D", "PerlinErosion13D", "PerlinIQ3D", "PerlinJordan3D", "PerlinRidged3D", "PerlinStandard3D", "PerlinSwiss3D", 
                                      "SimplexBadlands3D", "SimplexBillowed3D", "SimplexCellular3D", "SimplexIQ3D", "SimplexJordan3D", "SimplexPolkaDot3D", "SimplexRidged3D", "SimplexStandard3D", "SimplexSwiss3D", "Stars3D" };
    private static string[] NoiseGLSL = { "CellularNoise3D", "CellularNoiseF23D", "CellularNoiseMin3D", "CellularNoiseAdd3D", "CellularNoiseMul3D", "CubistNoise3D", "PolkaDot3D", "SparseConvolutionNoise3D", "ValueNoise3D",
                                      "HermiteBadlands3D", "HermiteBillowed3D", "HermiteIQ3D", "HermiteJordan3D", "HermiteRidged3D", "HermiteStandard3D", "HermiteSwiss3D",
                                      "PerlinBadlands3D", "PerlinBillowed3D", "PerlinIQ3D", "PerlinJordan3D", "PerlinRidged3D", "PerlinStandard3D", "PerlinSwiss3D", 
                                      "SimplexBadlands3D", "SimplexBillowed3D", "SimplexCellular3D", "SimplexIQ3D", "SimplexJordan3D", "SimplexPolkaDot3D", "SimplexRidged3D", "SimplexStandard3D", "SimplexSwiss3D" };*/

    private static string[] Quality = { "Very Low", "Low", "Medium", "High", "Very High" };

    private int pY = 95;
    private bool windows = true;
    private string shaderLanguage;

    public GameObject surface2D;
    private GameObject surface3D;

    private MeshRenderer renderer2D;
    private MeshRenderer renderer3D;

    //public Material[] materialsCG = new Material[Constants.NB_MAT_CG];
    public Material[] materialsVoronoiCG = new Material[Constants.NB_CG_VORONOI];
    public Material[] materialsHermiteCG = new Material[Constants.NB_HERMITE];
    public Material[] materialsPerlinCG = new Material[Constants.NB_PERLIN];
    public Material[] materialsSimplexCG = new Material[Constants.NB_SIMPLEX];
    public Material[] materialsAdvHermiteCG = new Material[Constants.NB_ADV_HERMITE];
    public Material[] materialsAdvPerlinCG = new Material[Constants.NB_ADV_PERLIN];
    public Material[] materialsAdvSimplexCG = new Material[Constants.NB_ADV_SIMPLEX];
    public Material[] materialsOtherCG = new Material[Constants.NB_OTHER];

    public Material[] materialsVoronoiLengthGLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL1];
    public Material[] materialsVoronoiLength2GLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsVoronoiManhattanGLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsVoronoiChebychevGLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsVoronoiQuadraticGLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsVoronoiMinkowski4GLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsVoronoiMinkowski5GLSL = new Material[Constants.NB_GLSL_VORONOI_IMPL2];
    public Material[] materialsHermiteGLSL = new Material[Constants.NB_HERMITE];
    public Material[] materialsPerlinGLSL = new Material[Constants.NB_PERLIN];
    public Material[] materialsSimplexGLSL = new Material[Constants.NB_SIMPLEX];
    public Material[] materialsAdvHermiteGLSL = new Material[Constants.NB_ADV_HERMITE];
    public Material[] materialsAdvPerlinGLSL = new Material[Constants.NB_ADV_PERLIN];
    public Material[] materialsAdvSimplexGLSL = new Material[Constants.NB_ADV_SIMPLEX];
    public Material[] materialsOtherGLSL = new Material[Constants.NB_OTHER];

    //public Material[] materialsGLSL = new Material[Constants.NB_MAT_GLSL];
    public Texture2D[] textures = new Texture2D[Constants.NB_TEX];

    private bool surfaceGenerated = false;
    //private bool showParameters = true;

    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public float surface3dPosX = 0.0f;
    public float surface3dPosY = 0.0f;
    public float surface3dWidth = 10.0f;
    public float surface3dLength = 10.0f;
    public int surface3dWidthSegments = 64;
    public int surface3dLengthSegments = 64;
    public Orientation surface3dOrientation = Orientation.Horizontal;

    private Mesh surface;

    GUIContent[] comboBoxListSurface;
    private ComboBox comboBoxControlSurface = new ComboBox();
    GUIContent[] comboBoxListNoise;
    private ComboBox comboBoxControlNoise = new ComboBox();

    GUIContent[] comboBoxListVoronoiCG;
    private ComboBox comboBoxControlVoronoiCG = new ComboBox();
    GUIContent[] comboBoxListVoronoiGLSL;
    private ComboBox comboBoxControlVoronoiGLSL = new ComboBox();
    GUIContent[] comboBoxListVoronoiImpl1GLSL;
    private ComboBox comboBoxControlVoronoiImpl1GLSL = new ComboBox();
    GUIContent[] comboBoxListVoronoiImpl2GLSL;
    private ComboBox comboBoxControlVoronoiImpl2GLSL = new ComboBox();
    GUIContent[] comboBoxListHermite;
    private ComboBox comboBoxControlHermite = new ComboBox();
    GUIContent[] comboBoxListPerlin;
    private ComboBox comboBoxControlPerlin = new ComboBox();
    GUIContent[] comboBoxListSimplex;
    private ComboBox comboBoxControlSimplex = new ComboBox();
    GUIContent[] comboBoxListAdvHermite;
    private ComboBox comboBoxControlAdvHermite = new ComboBox();
    GUIContent[] comboBoxListAdvPerlin;
    private ComboBox comboBoxControlAdvPerlin = new ComboBox();
    GUIContent[] comboBoxListAdvSimplex;
    private ComboBox comboBoxControlAdvSimplex = new ComboBox();
    GUIContent[] comboBoxListOther;
    private ComboBox comboBoxControlOther = new ComboBox();

    private ComboBox currentComboBox = new ComboBox();
    private ComboBox currentComboBoxVoronoi = new ComboBox();

    GUIContent[] comboBoxListTextureLow;
    private ComboBox comboBoxControlTextureLow = new ComboBox();
    GUIContent[] comboBoxListTextureHigh;
    private ComboBox comboBoxControlTextureHigh = new ComboBox();
    private GUIStyle listStyle = new GUIStyle();

    private bool showQuality = false;

    #region noise params

    private float[] octaves = new float[Constants.NB_MAT_GLSL];
    private float[] frequency = new float[Constants.NB_MAT_GLSL];
    private float[] amplitude = new float[Constants.NB_MAT_GLSL];
    private float[] lacunarity = new float[Constants.NB_MAT_GLSL];
    private float[] persistence = new float[Constants.NB_MAT_GLSL];
    private Vector4[] noiseOffset = new Vector4[Constants.NB_MAT_GLSL];
    private float[] contribution = new float[Constants.NB_MAT_GLSL];
    private float[] normalize = new float[Constants.NB_MAT_GLSL];
    private float[] animSpeed = new float[Constants.NB_MAT_GLSL];

    private float[] cellType = new float[Constants.NB_MAT_GLSL];
    private float[] distanceFunction = new float[Constants.NB_MAT_GLSL];
    private Vector4[] rangeClamp = new Vector4[Constants.NB_MAT_GLSL];
    private float[] floor = new float[Constants.NB_MAT_GLSL];
    private float[] powered = new float[Constants.NB_MAT_GLSL];
    private float[] ridgePower = new float[Constants.NB_MAT_GLSL];
    private float[] billowPower = new float[Constants.NB_MAT_GLSL];
    private float[] ridgeOffset = new float[Constants.NB_MAT_GLSL];
    private float[] warp = new float[Constants.NB_MAT_GLSL];
    private float[] warp0 = new float[Constants.NB_MAT_GLSL];
    private float[] damp = new float[Constants.NB_MAT_GLSL];
    private float[] damp0 = new float[Constants.NB_MAT_GLSL];
    private float[] dampScale = new float[Constants.NB_MAT_GLSL];
    private float[] radiusLow = new float[Constants.NB_MAT_GLSL];
    private float[] radiusHigh = new float[Constants.NB_MAT_GLSL];
    private float[] radius = new float[Constants.NB_MAT_GLSL];
    private float[] maxDimness = new float[Constants.NB_MAT_GLSL];
    private float[] probability = new float[Constants.NB_MAT_GLSL];

    private bool displace = false;
    private Vector4 lowColor = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
    private Vector4 highColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    private bool texturing = false;
    private bool texturesSet = false;
    private float lowTextureTiling = 4.0f;
    private float highTextureTiling = 4.0f;

    #endregion

    private int selectedItemIndexTextureLow = 0;
    private int selectedItemIndexTextureHigh = 0;

    void Awake()
    {
        renderer2D = surface2D.GetComponent<MeshRenderer>();
        renderer3D = GetComponent<MeshRenderer>();

        if (SystemInfo.operatingSystem.IndexOf("Windows") != -1)
        {
            windows = true;
            shaderLanguage = "CG";
            renderer2D.material = materialsPerlinCG[0];
            InitShadersCG();

            // DEBUG GLSL:
            /*windows = false;
            shaderLanguage = "GLSL";
            renderer2D.material = materialsVoronoiLengthGLSL[0];
            InitShadersGLSL();*/
        }
        else
        {
            // We're on Mac or mobile, so use GLSL
            windows = false;
            shaderLanguage = "GLSL";
            renderer2D.material = materialsVoronoiLengthGLSL[0];
            InitShadersGLSL();
        }
    }

    void Start()
    {
        comboBoxListSurface = new GUIContent[5];
        for (int i = 0; i < 5; i++)
        {
            comboBoxListSurface[i] = new GUIContent(Quality[i]);
        }

        comboBoxListNoise = new GUIContent[Constants.NB_TYPES];
        for (int i = 0; i < Constants.NB_TYPES; i++)
        {
            comboBoxListNoise[i] = new GUIContent(NoiseTypes[i]);
        }

        comboBoxListVoronoiCG = new GUIContent[Constants.NB_CG_VORONOI];
        for (int i = 0; i < Constants.NB_CG_VORONOI; i++)
        {
            comboBoxListVoronoiCG[i] = new GUIContent(VoronoiNoiseCG[i]);
        }
        comboBoxListVoronoiGLSL = new GUIContent[Constants.NB_GLSL_VORONOI];
        for (int i = 0; i < Constants.NB_GLSL_VORONOI; i++)
        {
            comboBoxListVoronoiGLSL[i] = new GUIContent(VoronoiNoiseGLSL[i]);
        }
        comboBoxListVoronoiImpl1GLSL = new GUIContent[Constants.NB_GLSL_VORONOI_IMPL1];
        for (int i = 0; i < Constants.NB_GLSL_VORONOI_IMPL1; i++)
        {
            comboBoxListVoronoiImpl1GLSL[i] = new GUIContent(VoronoiImpl1GLSL[i]);
        }
        comboBoxListVoronoiImpl2GLSL = new GUIContent[Constants.NB_GLSL_VORONOI_IMPL2];
        for (int i = 0; i < Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            comboBoxListVoronoiImpl2GLSL[i] = new GUIContent(VoronoiImpl2GLSL[i]);
        }
        comboBoxListHermite = new GUIContent[Constants.NB_HERMITE];
        for (int i = 0; i < Constants.NB_HERMITE; i++)
        {
            comboBoxListHermite[i] = new GUIContent(HermiteNoise[i]);
        }
        comboBoxListPerlin = new GUIContent[Constants.NB_PERLIN];
        for (int i = 0; i < Constants.NB_PERLIN; i++)
        {
            comboBoxListPerlin[i] = new GUIContent(PerlinNoise[i]);
        }
        comboBoxListSimplex = new GUIContent[Constants.NB_SIMPLEX];
        for (int i = 0; i < Constants.NB_SIMPLEX; i++)
        {
            comboBoxListSimplex[i] = new GUIContent(SimplexNoise[i]);
        }
        comboBoxListAdvHermite = new GUIContent[Constants.NB_ADV_HERMITE];
        for (int i = 0; i < Constants.NB_ADV_HERMITE; i++)
        {
            comboBoxListAdvHermite[i] = new GUIContent(AdvancedHermiteNoise[i]);
        }
        comboBoxListAdvPerlin = new GUIContent[Constants.NB_ADV_PERLIN];
        for (int i = 0; i < Constants.NB_ADV_PERLIN; i++)
        {
            comboBoxListAdvPerlin[i] = new GUIContent(AdvancedPerlinNoise[i]);
        }
        comboBoxListAdvSimplex = new GUIContent[Constants.NB_ADV_SIMPLEX];
        for (int i = 0; i < Constants.NB_ADV_SIMPLEX; i++)
        {
            comboBoxListAdvSimplex[i] = new GUIContent(AdvancedSimplexNoise[i]);
        }
        comboBoxListOther = new GUIContent[Constants.NB_OTHER];
        for (int i = 0; i < Constants.NB_OTHER; i++)
        {
            comboBoxListOther[i] = new GUIContent(OtherNoise[i]);
        }

        comboBoxListTextureLow = new GUIContent[Constants.NB_TEX];
        comboBoxListTextureHigh = new GUIContent[Constants.NB_TEX];
        for (int i = 0; i < Constants.NB_TEX; i++)
        {
            comboBoxListTextureLow[i] = new GUIContent(textures[i].name);
            comboBoxListTextureHigh[i] = new GUIContent(textures[i].name);
        }

        listStyle.normal.textColor = Color.white;
        listStyle.onHover.background =
        listStyle.hover.background = new Texture2D(2, 2);
        listStyle.padding.left =
        listStyle.padding.right =
        listStyle.padding.top =
        listStyle.padding.bottom = 4;

        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 6.0f;
        Camera.main.transform.localPosition = new Vector3(0.0f, 10.0f, 0.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

        if (windows)
        {
            renderer2D.material = materialsVoronoiCG[0];
            currentComboBox = comboBoxControlVoronoiCG;
        }
        else
        {
            renderer2D.material = materialsVoronoiLengthGLSL[0];
            currentComboBox = comboBoxControlVoronoiGLSL;
            currentComboBoxVoronoi = comboBoxControlVoronoiImpl1GLSL;
        }
    }

    #region GUI
    void OnGUI()
    {
        // Info
        GUI.Label(new Rect(Screen.width / 2 - 100, 10, 400, 21), "Turbulence Library - Workshop [" + shaderLanguage + "]");

        // Noise Type
        GUI.Label(new Rect(10, 10, 400, 21), "Noise Type :");
        int selectedItemIndexNoiseType = 0;
        int selectedItemIndexVoronoiCG = 0;
        int selectedItemIndexVoronoiGLSL = 0;
        int selectedItemIndexVoronoiImplGLSL = 0;
        int selectedItemIndexVoronoiImpl2GLSL = 0;
        int selectedItemIndexHermite = 0;
        int selectedItemIndexPerlin = 0;
        int selectedItemIndexSimplex = 0;
        int selectedItemIndexAdvHermite = 0;
        int selectedItemIndexAdvPerlin = 0;
        int selectedItemIndexAdvSimplex = 0;
        int selectedItemIndexOther = 0;

        selectedItemIndexNoiseType = comboBoxControlNoise.GetSelectedItemIndex();
        int selectedItemIndexNoiseType_old = selectedItemIndexNoiseType;
        selectedItemIndexNoiseType = comboBoxControlNoise.List(new Rect(10, 30, 170, 21), comboBoxListNoise[selectedItemIndexNoiseType].text, comboBoxListNoise, listStyle, "down");

        // Change Noise Type
        if (selectedItemIndexNoiseType != selectedItemIndexNoiseType_old)
        {
            switch (selectedItemIndexNoiseType)
            {
                case 0:
                    if (windows)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiCG, 0);
                        currentComboBox = comboBoxControlVoronoiCG;
                    }
                    else
                    {
                        currentComboBox = comboBoxControlVoronoiGLSL;
                        switch (selectedItemIndexVoronoiGLSL)
                        {
                            case 0:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImplGLSL, selectedItemIndexVoronoiGLSL);
                                currentComboBoxVoronoi = comboBoxControlVoronoiImpl1GLSL;
                                break;
                            default:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImpl2GLSL, selectedItemIndexVoronoiGLSL);
                                currentComboBoxVoronoi = comboBoxControlVoronoiImpl1GLSL;
                                break;
                        }
                    }
                    break;
                case 1:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexHermite, 0);
                    currentComboBox = comboBoxControlHermite;
                    break;
                case 2:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexPerlin, 0);
                    currentComboBox = comboBoxControlPerlin;
                    break;
                case 3:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexSimplex, 0);
                    currentComboBox = comboBoxControlSimplex;
                    break;
                case 4:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvHermite, 0);
                    currentComboBox = comboBoxControlAdvHermite;
                    break;
                case 5:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvPerlin, 0);
                    currentComboBox = comboBoxControlAdvPerlin;
                    break;
                case 6:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvSimplex, 0);
                    currentComboBox = comboBoxControlAdvSimplex;
                    break;
                case 7:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexOther, 0);
                    currentComboBox = comboBoxControlOther;
                    break;
            }
            UpdateTexturing();
        }

        // Noise Implementation
        if (!comboBoxControlNoise.IsSelecting())
        {
            GUI.Label(new Rect(10, 50, 400, 21), "Noise Implementation :");
            switch (selectedItemIndexNoiseType)
            {
                case 0:
                    if (windows)
                    {
                        selectedItemIndexVoronoiCG = comboBoxControlVoronoiCG.GetSelectedItemIndex();
                        int selectedItemIndexVoronoiCG_old = selectedItemIndexVoronoiCG;
                        selectedItemIndexVoronoiCG = comboBoxControlVoronoiCG.List(new Rect(10, 70, 170, 21), comboBoxListVoronoiCG[selectedItemIndexVoronoiCG].text, comboBoxListVoronoiCG, listStyle, "down");
                        if (selectedItemIndexVoronoiCG != selectedItemIndexVoronoiCG_old)
                        {
                            setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiCG, 0);
                            UpdateTexturing();
                        }
                    }
                    else
                    {
                        selectedItemIndexVoronoiGLSL = comboBoxControlVoronoiGLSL.GetSelectedItemIndex();
                        int selectedItemIndexVoronoiGLSL_old = selectedItemIndexVoronoiGLSL;
                        selectedItemIndexVoronoiGLSL = comboBoxControlVoronoiGLSL.List(new Rect(10, 70, 170, 21), comboBoxListVoronoiGLSL[selectedItemIndexVoronoiGLSL].text, comboBoxListVoronoiGLSL, listStyle, "down");
                        if (selectedItemIndexVoronoiGLSL != selectedItemIndexVoronoiGLSL_old)
                        {
                            currentComboBox = comboBoxControlVoronoiGLSL;
                            switch (selectedItemIndexVoronoiGLSL)
                            {
                                case 0:
                                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImplGLSL, selectedItemIndexVoronoiGLSL);
                                    UpdateTexturing();
                                    currentComboBoxVoronoi = comboBoxControlVoronoiImpl1GLSL;
                                    break;
                                default:
                                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImpl2GLSL, selectedItemIndexVoronoiGLSL);
                                    UpdateTexturing();
                                    currentComboBoxVoronoi = comboBoxControlVoronoiImpl2GLSL;
                                    break;
                            }
                        }
                    }
                    break;
                case 1:
                    selectedItemIndexHermite = comboBoxControlHermite.GetSelectedItemIndex();
                    int selectedItemIndexHermite_old = selectedItemIndexHermite;
                    selectedItemIndexHermite = comboBoxControlHermite.List(new Rect(10, 70, 170, 21), comboBoxListHermite[selectedItemIndexHermite].text, comboBoxListHermite, listStyle, "down");
                    if (selectedItemIndexHermite != selectedItemIndexHermite_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexHermite, 0);
                        UpdateTexturing();
                    }
                    break;
                case 2:
                    selectedItemIndexPerlin = comboBoxControlPerlin.GetSelectedItemIndex();
                    int selectedItemIndexPerlin_old = selectedItemIndexPerlin;
                    selectedItemIndexPerlin = comboBoxControlPerlin.List(new Rect(10, 70, 170, 21), comboBoxListPerlin[selectedItemIndexPerlin].text, comboBoxListPerlin, listStyle, "down");
                    if (selectedItemIndexPerlin != selectedItemIndexPerlin_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexPerlin, 0);
                        UpdateTexturing();
                    }
                    break;
                case 3:
                    selectedItemIndexSimplex = comboBoxControlSimplex.GetSelectedItemIndex();
                    int selectedItemIndexSimplex_old = selectedItemIndexSimplex;
                    selectedItemIndexSimplex = comboBoxControlSimplex.List(new Rect(10, 70, 170, 21), comboBoxListSimplex[selectedItemIndexSimplex].text, comboBoxListSimplex, listStyle, "down");
                    if (selectedItemIndexSimplex != selectedItemIndexSimplex_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexSimplex, 0);
                        UpdateTexturing();
                    }
                    break;
                case 4:
                    selectedItemIndexAdvHermite = comboBoxControlAdvHermite.GetSelectedItemIndex();
                    int selectedItemIndexAdvHermite_old = selectedItemIndexAdvHermite;
                    selectedItemIndexAdvHermite = comboBoxControlAdvHermite.List(new Rect(10, 70, 170, 21), comboBoxListAdvHermite[selectedItemIndexAdvHermite].text, comboBoxListAdvHermite, listStyle, "down");
                    if (selectedItemIndexAdvHermite != selectedItemIndexAdvHermite_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvHermite, 0);
                        UpdateTexturing();
                    }
                    break;
                case 5:
                    selectedItemIndexAdvPerlin = comboBoxControlAdvPerlin.GetSelectedItemIndex();
                    int selectedItemIndexAdvPerlin_old = selectedItemIndexAdvPerlin;
                    selectedItemIndexAdvPerlin = comboBoxControlAdvPerlin.List(new Rect(10, 70, 170, 21), comboBoxListAdvPerlin[selectedItemIndexAdvPerlin].text, comboBoxListAdvPerlin, listStyle, "down");
                    if (selectedItemIndexAdvPerlin != selectedItemIndexAdvPerlin_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvPerlin, 0);
                        UpdateTexturing();
                    }
                    break;
                case 6:
                    selectedItemIndexAdvSimplex = comboBoxControlAdvSimplex.GetSelectedItemIndex();
                    int selectedItemIndexAdvSimplex_old = selectedItemIndexAdvSimplex;
                    selectedItemIndexAdvSimplex = comboBoxControlAdvSimplex.List(new Rect(10, 70, 170, 21), comboBoxListAdvSimplex[selectedItemIndexAdvSimplex].text, comboBoxListAdvSimplex, listStyle, "down");
                    if (selectedItemIndexAdvSimplex != selectedItemIndexAdvSimplex_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvSimplex, 0);
                        UpdateTexturing();
                    }
                    break;
                case 7:
                    selectedItemIndexOther = comboBoxControlOther.GetSelectedItemIndex();
                    int selectedItemIndexOther_old = selectedItemIndexOther;
                    selectedItemIndexOther = comboBoxControlOther.List(new Rect(10, 70, 170, 21), comboBoxListOther[selectedItemIndexOther].text, comboBoxListOther, listStyle, "down");
                    if (selectedItemIndexOther != selectedItemIndexOther_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexOther, 0);
                        UpdateTexturing();
                    }
                    break;
            }
        }

        if (currentComboBox == comboBoxControlVoronoiGLSL && (!windows && (!comboBoxControlNoise.IsSelecting() && !comboBoxControlVoronoiGLSL.IsSelecting())))
        {
            GUI.Label(new Rect(10, 90, 400, 21), "Noise Implementation :");
            switch (selectedItemIndexVoronoiGLSL)
            {
                case 0:
                    selectedItemIndexVoronoiImplGLSL = comboBoxControlVoronoiImpl1GLSL.GetSelectedItemIndex();
                    int selectedItemIndexVoronoiImplGLSL_old = selectedItemIndexVoronoiImplGLSL;
                    selectedItemIndexVoronoiImplGLSL = comboBoxControlVoronoiImpl1GLSL.List(new Rect(10, 110, 170, 21), comboBoxListVoronoiImpl1GLSL[selectedItemIndexVoronoiImplGLSL].text, comboBoxListVoronoiImpl1GLSL, listStyle, "down");
                    if (selectedItemIndexVoronoiImplGLSL != selectedItemIndexVoronoiImplGLSL_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImplGLSL, selectedItemIndexVoronoiGLSL);
                        UpdateTexturing();
                        currentComboBoxVoronoi = comboBoxControlVoronoiImpl1GLSL;
                    }
                    break;
                default:
                    selectedItemIndexVoronoiImpl2GLSL = comboBoxControlVoronoiImpl2GLSL.GetSelectedItemIndex();
                    int selectedItemIndexVoronoiImpl2GLSL_old = selectedItemIndexVoronoiImpl2GLSL;
                    selectedItemIndexVoronoiImpl2GLSL = comboBoxControlVoronoiImpl2GLSL.List(new Rect(10, 110, 170, 21), comboBoxListVoronoiImpl2GLSL[selectedItemIndexVoronoiImpl2GLSL].text, comboBoxListVoronoiImpl2GLSL, listStyle, "down");
                    if (selectedItemIndexVoronoiImpl2GLSL != selectedItemIndexVoronoiImpl2GLSL_old)
                    {
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImpl2GLSL, selectedItemIndexVoronoiGLSL);
                        UpdateTexturing();
                        currentComboBoxVoronoi = comboBoxControlVoronoiImpl2GLSL;
                    }
                    break;
            }
        }

        // Noise Parameters
        //showParameters = GUI.Toggle(new Rect(190, 30, 150, 21), showParameters, "Show Parameters");
        if (!comboBoxControlNoise.IsSelecting() && !currentComboBox.IsSelecting() && !currentComboBoxVoronoi.IsSelecting())
        {
            if (windows)
            {
                switch (selectedItemIndexNoiseType)
                {
                    case 0:
                        ShowParametersCG(selectedItemIndexVoronoiCG, showQuality);
                        break;
                    case 1:
                        ShowParametersCG(Constants.NB_CG_VORONOI + selectedItemIndexHermite, showQuality);
                        break;
                    case 2:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + selectedItemIndexPerlin, showQuality);
                        break;
                    case 3:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + selectedItemIndexSimplex, showQuality);
                        break;
                    case 4:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + selectedItemIndexAdvHermite, showQuality);
                        break;
                    case 5:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + selectedItemIndexAdvPerlin, showQuality);
                        break;
                    case 6:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + selectedItemIndexAdvSimplex, showQuality);
                        break;
                    case 7:
                        ShowParametersCG(Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX + selectedItemIndexOther, showQuality);
                        break;
                }
            }
            else
            {
                switch (selectedItemIndexNoiseType)
                {
                    case 0:
                        ShowParametersGLSL(0, showQuality);
                        break;
                    case 1:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + selectedItemIndexHermite, showQuality);
                        break;
                    case 2:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + selectedItemIndexPerlin, showQuality);
                        break;
                    case 3:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + selectedItemIndexSimplex, showQuality);
                        break;
                    case 4:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + selectedItemIndexAdvHermite, showQuality);
                        break;
                    case 5:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + selectedItemIndexAdvPerlin, showQuality);
                        break;
                    case 6:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + selectedItemIndexAdvSimplex, showQuality);
                        break;
                    case 7:
                        ShowParametersGLSL(Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX + selectedItemIndexOther, showQuality);
                        break;
                }
            }
        }

        // Texturing
        if (!displace)
            texturing = GUI.Toggle(new Rect(Screen.width - 120, 75, 150, 21), texturing, "Enable Texturing");
        else if (displace && !comboBoxControlSurface.IsSelecting())
            texturing = GUI.Toggle(new Rect(Screen.width - 120, 120, 150, 21), texturing, "Enable Texturing");
        if (texturing)
        {
            if (!texturesSet)
            {
                renderer2D.material.SetFloat("_Texturing", 1.0f);
                renderer2D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer2D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
                renderer3D.material.SetFloat("_Texturing", 1.0f);
                renderer3D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer3D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
                texturesSet = true;
            }
            if (windows ? !comboBoxControlNoise.IsSelecting() : !comboBoxControlNoise.IsSelecting())
            {
                if (!comboBoxControlTextureLow.IsSelecting())
                    GUI.Label(new Rect(10, Screen.height - 160, 400, 21), "Low Texture :");
                selectedItemIndexTextureLow = comboBoxControlTextureLow.GetSelectedItemIndex();
                int selectedItemIndexTextureLow_old = selectedItemIndexTextureLow;
                selectedItemIndexTextureLow = comboBoxControlTextureLow.List(new Rect(10, Screen.height - 140, 100, 21), comboBoxListTextureLow[selectedItemIndexTextureLow].text, comboBoxListTextureLow, listStyle, "up");
                if (selectedItemIndexTextureLow != selectedItemIndexTextureLow_old)
                {
                    UpdateLowTexture(selectedItemIndexTextureLow);
                }
            }
            if (!comboBoxControlTextureHigh.IsSelecting())
                GUI.Label(new Rect(Screen.width - 120, Screen.height - 160, 400, 21), "High Texture :");
            selectedItemIndexTextureHigh = comboBoxControlTextureHigh.GetSelectedItemIndex();
            int selectedItemIndexTextureHigh_old = selectedItemIndexTextureHigh;
            selectedItemIndexTextureHigh = comboBoxControlTextureHigh.List(new Rect(Screen.width - 120, Screen.height - 140, 100, 21), comboBoxListTextureHigh[selectedItemIndexTextureHigh].text, comboBoxListTextureHigh, listStyle, "up");
            if (selectedItemIndexTextureHigh != selectedItemIndexTextureHigh_old)
            {
                UpdateHighTexture(selectedItemIndexTextureHigh);
            }
        }
        else
        {
            texturesSet = false;
            if (!displace)
                renderer2D.material.SetFloat("_Texturing", -1.0f);
            else
                renderer3D.material.SetFloat("_Texturing", -1.0f);
        }

        // Texture Tiling
        if (texturing)
        {
            GUI.Label(new Rect(10, Screen.height - 120, 400, 21), "Low Texture Tiling :");
            lowTextureTiling = GUI.HorizontalSlider(new Rect(10, Screen.height - 95, 150, 12), lowTextureTiling, 1.0f, 8.0f);
            GUI.Label(new Rect(170, Screen.height - 100, 100, 21), lowTextureTiling.ToString("#0.00"));
            UpdateLowTextureTiling();
            GUI.Label(new Rect(Screen.width - 120, Screen.height - 120, 400, 21), "High Texture Tiling :");
            highTextureTiling = GUI.HorizontalSlider(new Rect(Screen.width - 160, Screen.height - 95, 150, 12), highTextureTiling, 1.0f, 8.0f);
            GUI.Label(new Rect(Screen.width - 190, Screen.height - 100, 100, 21), highTextureTiling.ToString("#0.00"));
            UpdateHighTextureTiling();
        }

        // Coloring
        GUI.Label(new Rect(10, Screen.height - 80, 400, 21), "Low Color :");
        lowColor.x = GUI.HorizontalSlider(new Rect(10, Screen.height - 55, 150, 12), lowColor.x, 0.0f, 1.0f);
        GUI.Label(new Rect(170, Screen.height - 60, 100, 21), lowColor.x.ToString("#0.00"));
        lowColor.y = GUI.HorizontalSlider(new Rect(10, Screen.height - 35, 150, 12), lowColor.y, 0.0f, 1.0f);
        GUI.Label(new Rect(170, Screen.height - 40, 100, 21), lowColor.y.ToString("#0.00"));
        lowColor.z = GUI.HorizontalSlider(new Rect(10, Screen.height - 15, 150, 12), lowColor.z, 0.0f, 1.0f);
        GUI.Label(new Rect(170, Screen.height - 20, 100, 21), lowColor.z.ToString("#0.00"));
        UpdateLowColor();
        GUI.Label(new Rect(Screen.width - 120, Screen.height - 80, 400, 21), "High Color :");
        highColor.x = GUI.HorizontalSlider(new Rect(Screen.width - 160, Screen.height - 55, 150, 12), highColor.x, 1.0f, 0.0f);
        GUI.Label(new Rect(Screen.width - 190, Screen.height - 60, 100, 21), highColor.x.ToString("#0.00"));
        highColor.y = GUI.HorizontalSlider(new Rect(Screen.width - 160, Screen.height - 35, 150, 12), highColor.y, 1.0f, 0.0f);
        GUI.Label(new Rect(Screen.width - 190, Screen.height - 40, 100, 21), highColor.y.ToString("#0.00"));
        highColor.z = GUI.HorizontalSlider(new Rect(Screen.width - 160, Screen.height - 15, 150, 12), highColor.z, 1.0f, 0.0f);
        GUI.Label(new Rect(Screen.width - 190, Screen.height - 20, 100, 21), highColor.z.ToString("#0.00"));
        UpdateHighColor();

        // Rendering Method
        GUI.Label(new Rect(Screen.width - 120, 10, 400, 21), "Rendering Method :");
        if (GUI.Button(new Rect(Screen.width - 120, 30, 100, 21), "2D Surface"))
        {
            displace = false;
            showQuality = false;
            renderer3D.enabled = false;
            Camera.main.orthographic = true;
            Camera.main.orthographicSize = 6.0f;
            Camera.main.transform.localPosition = new Vector3(0.0f, 10.0f, 0.0f);
            Camera.main.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            surface2D.active = true;
            switch (selectedItemIndexNoiseType)
            {
                case 0:
                    if (windows)
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiCG, 0);
                    else
                    {
                        switch (selectedItemIndexVoronoiGLSL)
                        {
                            case 0:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImplGLSL, selectedItemIndexVoronoiGLSL);
                                break;
                            case 1:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImpl2GLSL, selectedItemIndexVoronoiGLSL);
                                break;
                        }
                    }
                    break;
                case 1:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexHermite, 0);
                    break;
                case 2:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexPerlin, 0);
                    break;
                case 3:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexSimplex, 0);
                    break;
                case 4:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvHermite, 0);
                    break;
                case 5:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvPerlin, 0);
                    break;
                case 6:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvSimplex, 0);
                    break;
                case 7:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexOther, 0);
                    break;
            }
            renderer2D.material.SetFloat("_Displace", -1.0f);
            if (texturing)
            {
                renderer2D.material.SetFloat("_Texturing", 1.0f);
                renderer2D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer2D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
            }
        }
        if (GUI.Button(new Rect(Screen.width - 120, 50, 100, 21), "3D Surface"))
        {
            displace = true;
            showQuality = true;
            surface2D.active = false;
            renderer3D.enabled = true;
            Camera.main.orthographic = false;
            Camera.main.transform.localPosition = new Vector3(0.0f, 5.0f, 7.0f);
            Camera.main.transform.localRotation = Quaternion.Euler(40.0f, 180.0f, 0.0f);
            if (!surfaceGenerated)
                GenerateSurface();
            surfaceGenerated = true;
            switch (selectedItemIndexNoiseType)
            {
                case 0:
                    if (windows)
                        setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiCG, 0);
                    else
                    {
                        switch (selectedItemIndexVoronoiGLSL)
                        {
                            case 0:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImplGLSL, selectedItemIndexVoronoiGLSL);
                                break;
                            case 1:
                                setMaterial(selectedItemIndexNoiseType, selectedItemIndexVoronoiImpl2GLSL, selectedItemIndexVoronoiGLSL);
                                break;
                        }
                    }
                    break;
                case 1:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexHermite, 0);
                    break;
                case 2:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexPerlin, 0);
                    break;
                case 3:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexSimplex, 0);
                    break;
                case 4:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvHermite, 0);
                    break;
                case 5:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvPerlin, 0);
                    break;
                case 6:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexAdvSimplex, 0);
                    break;
                case 7:
                    setMaterial(selectedItemIndexNoiseType, selectedItemIndexOther, 0);
                    break;
            }
            renderer3D.material.SetFloat("_Displace", 1.0f);

            if (texturing)
            {
                renderer3D.material.SetFloat("_Texturing", 1.0f);
                renderer3D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer3D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
            }
        }

        // Surface Quality
        if (showQuality)
        {
            GUI.Label(new Rect(Screen.width - 120, 75, 400, 21), "Surface Quality :");
            int selectedItemIndexSurface = comboBoxControlSurface.GetSelectedItemIndex();
            int selectedItemIndexSurface_old = selectedItemIndexSurface;
            selectedItemIndexSurface = comboBoxControlSurface.List(new Rect(Screen.width - 120, 95, 100, 21), comboBoxListSurface[selectedItemIndexSurface].text, comboBoxListSurface, listStyle, "down");
            if (selectedItemIndexSurface != selectedItemIndexSurface_old)
            {
                switch (selectedItemIndexSurface)
                {
                    case 0:
                        surface3dWidthSegments = 64;
                        surface3dLengthSegments = 64;
                        break;
                    case 1:
                        surface3dWidthSegments = 96;
                        surface3dLengthSegments = 96;
                        break;
                    case 2:
                        surface3dWidthSegments = 128;
                        surface3dLengthSegments = 128;
                        break;
                    case 3:
                        surface3dWidthSegments = 192;
                        surface3dLengthSegments = 192;
                        break;
                    case 4:
                        surface3dWidthSegments = 254;
                        surface3dLengthSegments = 254;
                        break;
                }
                GenerateSurface();
            }
        }
    }
    #endregion

    #region Init CG
    void InitShadersCG()
    {
        int i = 0;
        for (i = 0; i < Constants.NB_CG_VORONOI; i++)
        {
            frequency[i] = materialsVoronoiCG[i].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiCG[i].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiCG[i].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiCG[i].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiCG[i].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiCG[i].GetFloat("_AnimSpeed");
            if (materialsVoronoiCG[i].HasProperty("_CellType")) cellType[i] = materialsVoronoiCG[i].GetFloat("_CellType");
            if (materialsVoronoiCG[i].HasProperty("_DistanceFunction")) distanceFunction[i] = materialsVoronoiCG[i].GetFloat("_DistanceFunction");
        }
        for (i = Constants.NB_CG_VORONOI; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE; i++)
        {
            octaves[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Octaves");
            frequency[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Frequency");
            amplitude[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Amplitude");
            lacunarity[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Lacunarity");
            persistence[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Persistence");
            noiseOffset[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetVector("_NoiseOffset");
            contribution[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Contribution");
            normalize[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Normalize");
            animSpeed[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_AnimSpeed");
            if (materialsHermiteCG[i - Constants.NB_CG_VORONOI].HasProperty("_Powered")) powered[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_Powered");
            if (materialsHermiteCG[i - Constants.NB_CG_VORONOI].HasProperty("_RidgePower")) ridgePower[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_RidgePower");
            if (materialsHermiteCG[i - Constants.NB_CG_VORONOI].HasProperty("_BillowPower")) billowPower[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_BillowPower");
            if (materialsHermiteCG[i - Constants.NB_CG_VORONOI].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsHermiteCG[i - Constants.NB_CG_VORONOI].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN; i++)
        {
            octaves[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Octaves");
            frequency[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Frequency");
            amplitude[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Amplitude");
            lacunarity[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Lacunarity");
            persistence[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Persistence");
            noiseOffset[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetVector("_NoiseOffset");
            contribution[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Contribution");
            normalize[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Normalize");
            animSpeed[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_AnimSpeed");
            if (materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].HasProperty("_Powered")) powered[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_Powered");
            if (materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].HasProperty("_RidgePower")) ridgePower[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_RidgePower");
            if (materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].HasProperty("_BillowPower")) billowPower[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_BillowPower");
            if (materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE)].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX; i++)
        {
            octaves[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Octaves");
            frequency[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Frequency");
            amplitude[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Amplitude");
            lacunarity[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Lacunarity");
            persistence[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Persistence");
            noiseOffset[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetVector("_NoiseOffset");
            contribution[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Contribution");
            normalize[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Normalize");
            animSpeed[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_AnimSpeed");
            if (materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].HasProperty("_Powered")) powered[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Powered");
            if (materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].HasProperty("_RidgePower")) ridgePower[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_RidgePower");
            if (materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].HasProperty("_BillowPower")) billowPower[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_BillowPower");
            if (materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE; i++)
        {
            octaves[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Octaves");
            frequency[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Contribution");
            normalize[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_AnimSpeed");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Floor")) floor[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Floor");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Powered")) powered[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Powered");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_RidgePower")) ridgePower[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_RidgePower");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_BillowPower")) billowPower[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_BillowPower");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_RidgeOffset");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Warp")) warp[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Warp");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Warp0")) warp0[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Warp0");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Damp")) damp[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Damp");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Damp0")) damp0[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Damp0");
            if (materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_DampScale")) dampScale[i] = materialsAdvHermiteCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN; i++)
        {
            octaves[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Octaves");
            frequency[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Contribution");
            normalize[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_AnimSpeed");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Floor")) floor[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Floor");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Powered")) powered[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Powered");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_RidgePower")) ridgePower[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_RidgePower");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_BillowPower")) billowPower[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_BillowPower");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_RidgeOffset");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Warp")) warp[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Warp");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Warp0")) warp0[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Warp0");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Damp")) damp[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Damp");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Damp0")) damp0[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Damp0");
            if (materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_DampScale")) dampScale[i] = materialsAdvPerlinCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX; i++)
        {
            octaves[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Octaves");
            frequency[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Contribution");
            normalize[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_AnimSpeed");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Floor")) floor[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Floor");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Powered")) powered[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Powered");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_RidgePower")) ridgePower[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_RidgePower");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_BillowPower")) billowPower[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_BillowPower");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_RidgeOffset");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Warp")) warp[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Warp");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Warp0")) warp0[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Warp0");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Damp")) damp[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Damp");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Damp0")) damp0[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Damp0");
            if (materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_DampScale")) dampScale[i] = materialsAdvSimplexCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX; i < Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX + Constants.NB_OTHER; i++)
        {
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Octaves")) octaves[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Octaves");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Frequency")) frequency[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Frequency");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Amplitude")) amplitude[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Amplitude");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Lacunarity")) lacunarity[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Lacunarity");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Persistence")) persistence[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Persistence");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_NoiseOffset")) noiseOffset[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetVector("_NoiseOffset");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Contribution")) contribution[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Contribution");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Normalize")) normalize[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Normalize");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_AnimSpeed")) animSpeed[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_AnimSpeed");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RangeClamp")) rangeClamp[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetVector("_RangeClamp");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RadiusLow")) radiusLow[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_RadiusLow");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RadiusHigh")) radiusHigh[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_RadiusHigh");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Radius")) radius[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Radius");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_MaxDimness")) maxDimness[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_MaxDimness");
            if (materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Probability")) probability[i] = materialsOtherCG[i - (Constants.NB_CG_VORONOI + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Probability");
        }
    }
    #endregion

    #region Init GLSL
    void InitShadersGLSL()
    {
        int i = 0;
        for (i = 0; i < Constants.NB_GLSL_VORONOI_IMPL1; i++)
        {
            frequency[i] = materialsVoronoiLengthGLSL[i].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiLengthGLSL[i].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiLengthGLSL[i].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiLengthGLSL[i].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiLengthGLSL[i].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiLengthGLSL[i].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1; i < Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiLength2GLSL[i - Constants.NB_GLSL_VORONOI_IMPL1].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiManhattanGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiChebychevGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 2 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiQuadraticGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 3 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiMinkowski4GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 4 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2; i++)
        {
            frequency[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            noiseOffset[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsVoronoiMinkowski5GLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 5 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE; i++)
        {
            frequency[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Frequency");
            amplitude[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Amplitude");
            lacunarity[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Lacunarity");
            persistence[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Persistence");
            noiseOffset[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetVector("_NoiseOffset");
            contribution[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Contribution");
            normalize[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_Normalize");
            animSpeed[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_AnimSpeed");
            if (materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2)].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN; i++)
        {
            frequency[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Frequency");
            amplitude[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Amplitude");
            lacunarity[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Lacunarity");
            persistence[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Persistence");
            noiseOffset[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetVector("_NoiseOffset");
            contribution[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Contribution");
            normalize[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_Normalize");
            animSpeed[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_AnimSpeed");
            if (materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE)].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX; i++)
        {
            frequency[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Frequency");
            amplitude[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Amplitude");
            lacunarity[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Lacunarity");
            persistence[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Persistence");
            noiseOffset[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetVector("_NoiseOffset");
            contribution[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Contribution");
            normalize[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_Normalize");
            animSpeed[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_AnimSpeed");
            if (materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN)].GetFloat("_RidgeOffset");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE; i++)
        {
            frequency[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Contribution");
            normalize[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_AnimSpeed");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Floor")) floor[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Floor");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_RidgeOffset");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Warp")) warp[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Warp");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Warp0")) warp0[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Warp0");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Damp")) damp[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Damp");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_Damp0")) damp0[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_Damp0");
            if (materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].HasProperty("_DampScale")) dampScale[i] = materialsAdvHermiteGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN; i++)
        {
            frequency[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Contribution");
            normalize[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_AnimSpeed");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Floor")) floor[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Floor");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_RidgeOffset");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Warp")) warp[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Warp");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Warp0")) warp0[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Warp0");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Damp")) damp[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Damp");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_Damp0")) damp0[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_Damp0");
            if (materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].HasProperty("_DampScale")) dampScale[i] = materialsAdvPerlinGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX; i++)
        {
            frequency[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Frequency");
            amplitude[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Amplitude");
            lacunarity[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Lacunarity");
            persistence[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Persistence");
            noiseOffset[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetVector("_NoiseOffset");
            contribution[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Contribution");
            normalize[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Normalize");
            animSpeed[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_AnimSpeed");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Floor")) floor[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Floor");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_RidgeOffset")) ridgeOffset[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_RidgeOffset");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Warp")) warp[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Warp");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Warp0")) warp0[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Warp0");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Damp")) damp[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Damp");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_Damp0")) damp0[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_Damp0");
            if (materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].HasProperty("_DampScale")) dampScale[i] = materialsAdvSimplexGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN)].GetFloat("_DampScale");
        }
        for (i = Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX; i < Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX + Constants.NB_OTHER; i++)
        {
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Frequency")) frequency[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Frequency");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Amplitude")) amplitude[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Amplitude");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Lacunarity")) lacunarity[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Lacunarity");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Persistence")) persistence[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Persistence");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_NoiseOffset")) noiseOffset[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetVector("_NoiseOffset");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Contribution")) contribution[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Contribution");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Normalize")) normalize[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Normalize");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_AnimSpeed")) animSpeed[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_AnimSpeed");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RangeClamp")) rangeClamp[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetVector("_RangeClamp");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RadiusLow")) radiusLow[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_RadiusLow");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_RadiusHigh")) radiusHigh[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_RadiusHigh");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Radius")) radius[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Radius");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_MaxDimness")) maxDimness[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_MaxDimness");
            if (materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].HasProperty("_Probability")) probability[i] = materialsOtherGLSL[i - (Constants.NB_GLSL_VORONOI_IMPL1 + 6 * Constants.NB_GLSL_VORONOI_IMPL2 + Constants.NB_HERMITE + Constants.NB_PERLIN + Constants.NB_SIMPLEX + Constants.NB_ADV_HERMITE + Constants.NB_ADV_PERLIN + Constants.NB_ADV_SIMPLEX)].GetFloat("_Probability");
        }
    }
    #endregion

    #region Surface
    void GenerateSurface()
    {
        surface = new Mesh();
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = surface;
        surface.name = "Surface";

        int hCount2 = surface3dWidthSegments + 1;
        int vCount2 = surface3dLengthSegments + 1;
        int numTriangles = surface3dWidthSegments * surface3dLengthSegments * 6;
        int numVertices = hCount2 * vCount2;

        Vector3[] vertices = new Vector3[numVertices];
        Vector2[] uvs = new Vector2[numVertices];
        int[] triangles = new int[numTriangles];

        int index = 0;
        float uvFactorX = 1.0f / surface3dWidthSegments;
        float uvFactorY = 1.0f / surface3dLengthSegments;
        float scaleX = surface3dWidth / surface3dWidthSegments;
        float scaleY = surface3dLength / surface3dLengthSegments;
        for (float y = 0.0f; y < vCount2; y++)
        {
            for (float x = 0.0f; x < hCount2; x++)
            {
                if (surface3dOrientation == Orientation.Horizontal)
                {
                    vertices[index] = new Vector3(x * scaleX - surface3dWidth / 2f, 0.0f, y * scaleY - surface3dLength / 2f);
                }
                else
                {
                    vertices[index] = new Vector3(x * scaleX - surface3dWidth / 2f, y * scaleY - surface3dLength / 2f, 0.0f);
                }
                uvs[index++] = new Vector2(x * uvFactorX, y * uvFactorY);
            }
        }

        index = 0;
        for (int y = 0; y < surface3dLengthSegments; y++)
        {
            for (int x = 0; x < surface3dWidthSegments; x++)
            {
                triangles[index] = (y * hCount2) + x;
                triangles[index + 1] = ((y + 1) * hCount2) + x;
                triangles[index + 2] = (y * hCount2) + x + 1;

                triangles[index + 3] = ((y + 1) * hCount2) + x;
                triangles[index + 4] = ((y + 1) * hCount2) + x + 1;
                triangles[index + 5] = (y * hCount2) + x + 1;
                index += 6;
            }
        }

        surface.vertices = vertices;
        surface.uv = uvs;
        surface.triangles = triangles;
        surface.RecalculateNormals();

        meshFilter.sharedMesh = surface;
        surface.RecalculateBounds();
    }
    #endregion

    void setMaterial(int noiseType, int index, int voronoiType)
    {
        if (displace)
        {
            if (windows)
            {
                switch (noiseType)
                {
                    case 0:
                        renderer3D.material = materialsVoronoiCG[index];
                        break;
                    case 1:
                        renderer3D.material = materialsHermiteCG[index];
                        break;
                    case 2:
                        renderer3D.material = materialsPerlinCG[index];
                        break;
                    case 3:
                        renderer3D.material = materialsSimplexCG[index];
                        break;
                    case 4:
                        renderer3D.material = materialsAdvHermiteCG[index];
                        break;
                    case 5:
                        renderer3D.material = materialsAdvPerlinCG[index];
                        break;
                    case 6:
                        renderer3D.material = materialsAdvSimplexCG[index];
                        break;
                    case 7:
                        renderer3D.material = materialsOtherCG[index];
                        break;
                }
            }
            else
            {
                switch (noiseType)
                {
                    case 0:
                        switch (voronoiType)
                        {
                            case 0:
                                renderer3D.material = materialsVoronoiLengthGLSL[index];
                                break;
                            case 1:
                                renderer3D.material = materialsVoronoiLength2GLSL[index];
                                break;
                            case 2:
                                renderer3D.material = materialsVoronoiManhattanGLSL[index];
                                break;
                            case 3:
                                renderer3D.material = materialsVoronoiChebychevGLSL[index];
                                break;
                            case 4:
                                renderer3D.material = materialsVoronoiQuadraticGLSL[index];
                                break;
                            case 5:
                                renderer3D.material = materialsVoronoiMinkowski4GLSL[index];
                                break;
                            case 6:
                                renderer3D.material = materialsVoronoiMinkowski5GLSL[index];
                                break;
                        }
                        break;
                    case 1:
                        renderer3D.material = materialsHermiteGLSL[index];
                        break;
                    case 2:
                        renderer3D.material = materialsPerlinGLSL[index];
                        break;
                    case 3:
                        renderer3D.material = materialsSimplexGLSL[index];
                        break;
                    case 4:
                        renderer3D.material = materialsAdvHermiteGLSL[index];
                        break;
                    case 5:
                        renderer3D.material = materialsAdvPerlinGLSL[index];
                        break;
                    case 6:
                        renderer3D.material = materialsAdvSimplexGLSL[index];
                        break;
                    case 7:
                        renderer3D.material = materialsOtherGLSL[index];
                        break;
                }
            }
        }
        else
        {
            if (windows)
            {
                switch (noiseType)
                {
                    case 0:
                        renderer2D.material = materialsVoronoiCG[index];
                        break;
                    case 1:
                        renderer2D.material = materialsHermiteCG[index];
                        break;
                    case 2:
                        renderer2D.material = materialsPerlinCG[index];
                        break;
                    case 3:
                        renderer2D.material = materialsSimplexCG[index];
                        break;
                    case 4:
                        renderer2D.material = materialsAdvHermiteCG[index];
                        break;
                    case 5:
                        renderer2D.material = materialsAdvPerlinCG[index];
                        break;
                    case 6:
                        renderer2D.material = materialsAdvSimplexCG[index];
                        break;
                    case 7:
                        renderer2D.material = materialsOtherCG[index];
                        break;
                }
            }
            else
            {
                switch (noiseType)
                {
                    case 0:
                        switch (voronoiType)
                        {
                            case 0:
                                renderer2D.material = materialsVoronoiLengthGLSL[index];
                                break;
                            case 1:
                                renderer2D.material = materialsVoronoiLength2GLSL[index];
                                break;
                            case 2:
                                renderer2D.material = materialsVoronoiManhattanGLSL[index];
                                break;
                            case 3:
                                renderer2D.material = materialsVoronoiChebychevGLSL[index];
                                break;
                            case 4:
                                renderer2D.material = materialsVoronoiQuadraticGLSL[index];
                                break;
                            case 5:
                                renderer2D.material = materialsVoronoiMinkowski4GLSL[index];
                                break;
                            case 6:
                                renderer2D.material = materialsVoronoiMinkowski5GLSL[index];
                                break;
                        }
                        break;
                    case 1:
                        renderer2D.material = materialsHermiteGLSL[index];
                        break;
                    case 2:
                        renderer2D.material = materialsPerlinGLSL[index];
                        break;
                    case 3:
                        renderer2D.material = materialsSimplexGLSL[index];
                        break;
                    case 4:
                        renderer2D.material = materialsAdvHermiteGLSL[index];
                        break;
                    case 5:
                        renderer2D.material = materialsAdvPerlinGLSL[index];
                        break;
                    case 6:
                        renderer2D.material = materialsAdvSimplexGLSL[index];
                        break;
                    case 7:
                        renderer2D.material = materialsOtherGLSL[index];
                        break;
                }
            }
        }
    }

    #region ParamsCG
    void ShowParametersCG(int index, bool is3D)
    {
        switch (index)
        {
            case 0: // Voronoi
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Cell Type", cellType, index, 0.0f, 9.0f, "#0");
                ShowParameter("Distance Func", distanceFunction, index, 0.0f, 7.0f, "#0");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 24: // Cubist
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Range", rangeClamp, 2, index, -3.0f, 2.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 25: // Polka Dot
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius Low", radiusLow, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Radius High", radiusHigh, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 26: // Polka Square
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius Low", radiusLow, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Radius High", radiusHigh, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 28: // Sparse
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 23: // Value
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 14: // H Badlands
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 3: // H Billowed
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Billow Power", billowPower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 11: // H IQ
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 12: // H Jordan
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 4: // H Ridged
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 2: // H Standard
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 13: // H Swiss
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 18: // P Badlands
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 6: // P Billowed
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Billow Power", billowPower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            /*case 15: // P Erosion 1
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;*/
            case 15: // P IQ
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 16: // P Jordan
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 7: // P Ridged
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 5: // P Standard
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 17: // P Swiss
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 22: // S Badlands
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 9: // S Billowed
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Billow Power", billowPower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 1: // S Cellular
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 19: // S IQ 
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 20: // S Jordan
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 27: // S Polka
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius", radius, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Max Dimness", maxDimness, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 10: // S Ridged
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 8: // S Standard
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 21: // S Swiss
                pY = 95;
                if (windows) ShowParameter("Octaves", octaves, index, 0.0f, 20.0f, "#0");

                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Powered", powered, index, -1.0f, 1.0f, "#0");
                ShowParameter("Ridge Power", ridgePower, index, 1.0f, 4.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 29: // Stars
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius", radius, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Probability", probability, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Max Dimness", maxDimness, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
        }
    }
    #endregion

    #region ParamsGLSL
    void ShowParametersGLSL(int index, bool is3D)
    {
        switch (index)
        {
            case 86: // Cubist
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Range", rangeClamp, 2, index, -3.0f, 2.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 87: // Polka Dot
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius Low", radiusLow, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Radius High", radiusHigh, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 88: // Polka Square
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius Low", radiusLow, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Radius High", radiusHigh, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 90: // Sparse
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 85: // Value
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 76: // H Badlands
                pY = 95;
                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 65: // H Billowed
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 73: // H IQ
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 74: // H Jordan
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 66: // H Ridged
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 64: // H Standard
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 75: // H Swiss
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 80: // P Badlands
                pY = 95;
                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 68: // P Billowed
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 77: // P IQ
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 78: // P Jordan
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 69: // P Ridged
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 67: // P Standard
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 79: // P Swiss
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 84: // S Badlands
                pY = 95;
                ShowParameter("Floor", floor, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 71: // S Billowed
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 81: // S IQ 
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 82: // S Jordan
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Warp 0", warp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Warp", warp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp 0", damp0, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp", damp, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Damp Scale", dampScale, index, -2.0f, 2.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 89: // S Polka
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius", radius, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Max Dimness", maxDimness, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 72: // S Ridged
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 70: // S Standard
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 83: // S Swiss
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Lacunarity", lacunarity, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Persistence", persistence, index, 0.0f, 2.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Ridge Offset", ridgeOffset, index, -2.0f, 3.0f, "#0.00");
                ShowParameter("Warp", warp, index, -1.0f, 1.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            case 91: // Stars
                pY = 95;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Radius", radius, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Probability", probability, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Max Dimness", maxDimness, index, 0.0f, 1.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
            default:
                pY = 135;
                ShowParameter("Frequency", frequency, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Amplitude", amplitude, index, 0.0f, 5.0f, "#0.00");
                ShowParameter("Offset", noiseOffset, 3, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Contribution", contribution, index, -3.0f, 3.0f, "#0.00");
                ShowParameter("Normalize", normalize, index, -1.0f, 1.0f, "#0");
                ShowParameter("Anim Speed", animSpeed, index, 0.0f, 10.0f, "#0.00");
                pY = 0;
                UpdateParameters(index);
                break;
        }
    }

    void ShowParameter(string name, float[] parameter, int index, float rangeLow, float rangeHigh, string format)
    {
        GUI.Label(new Rect(10, pY, 100, 21), name);
        parameter[index] = GUI.HorizontalSlider(new Rect(80, pY + 5, 100, 12), parameter[index], rangeLow, rangeHigh);
        GUI.Label(new Rect(190, pY, 100, 21), parameter[index].ToString(format));
        pY += 20;
    }

    /*void ShowGLSLQuality(int index)
    {
        GUI.Label(new Rect(10, pY, 100, 21), "Quality");
        int glslQuality_old = glslQuality;
        glslQuality = GUI.Toolbar(new Rect(80, pY, 200, 21), glslQuality, glslQualityStrings);
        if (glslQuality != glslQuality_old)
            UpdateGLSLQuality(index);
        pY += 20;
    }*/

    void ShowParameter(string name, Vector4[] parameter, int dimensions, int index, float rangeLow, float rangeHigh, string format)
    {
        if (dimensions >= 1)
        {
            GUI.Label(new Rect(10, pY, 100, 21), name + " X");
            parameter[index].x = GUI.HorizontalSlider(new Rect(80, pY + 5, 100, 12), parameter[index].x, rangeLow, rangeHigh);
            GUI.Label(new Rect(190, pY, 100, 21), parameter[index].x.ToString(format));
            pY += 20;
        }
        if (dimensions >= 2)
        {
            GUI.Label(new Rect(10, pY, 100, 21), name + " Y");
            parameter[index].y = GUI.HorizontalSlider(new Rect(80, pY + 5, 100, 12), parameter[index].y, rangeLow, rangeHigh);
            GUI.Label(new Rect(190, pY, 100, 21), parameter[index].y.ToString(format));
            pY += 20;
        }
        if (dimensions >= 3)
        {
            GUI.Label(new Rect(10, pY, 100, 21), name + " Z");
            parameter[index].z = GUI.HorizontalSlider(new Rect(80, pY + 5, 100, 12), parameter[index].z, rangeLow, rangeHigh);
            GUI.Label(new Rect(190, pY, 100, 21), parameter[index].z.ToString(format));
            pY += 20;
        }
    }
    #endregion

    #region Updates
    void UpdateLowColor()
    {
        if (!displace)
            renderer2D.material.SetVector("_LowColor", lowColor);
        else
            renderer3D.material.SetVector("_LowColor", lowColor);
    }

    void UpdateHighColor()
    {
        if (!displace)
            renderer2D.material.SetVector("_HighColor", highColor);
        else
            renderer3D.material.SetVector("_HighColor", highColor);
    }

    void UpdateLowTexture(int texIndex)
    {
        if (!displace)
            renderer2D.material.SetTexture("_LowTexture", textures[texIndex]);
        else
            renderer3D.material.SetTexture("_LowTexture", textures[texIndex]);
    }

    void UpdateHighTexture(int texIndex)
    {
        if (!displace)
            renderer2D.material.SetTexture("_HighTexture", textures[texIndex]);
        else
            renderer3D.material.SetTexture("_HighTexture", textures[texIndex]);
    }

    void UpdateLowTextureTiling()
    {
        if (!displace)
            renderer2D.material.SetVector("_LowTexture_ST", new Vector4(lowTextureTiling, lowTextureTiling, 0.0f, 0.0f));
        else
            renderer3D.material.SetVector("_LowTexture_ST", new Vector4(lowTextureTiling, lowTextureTiling, 0.0f, 0.0f));
    }

    void UpdateHighTextureTiling()
    {
        if (!displace)
            renderer2D.material.SetVector("_HighTexture_ST", new Vector4(highTextureTiling, highTextureTiling, 0.0f, 0.0f));
        else
            renderer3D.material.SetVector("_HighTexture_ST", new Vector4(highTextureTiling, highTextureTiling, 0.0f, 0.0f));
    }

    void UpdateParameters(int index)
    {
        if (!displace)
        {
            if (windows) renderer2D.material.SetFloat("_Octaves", octaves[index]);
            renderer2D.material.SetFloat("_Frequency", frequency[index]);
            renderer2D.material.SetFloat("_Amplitude", amplitude[index]);
            renderer2D.material.SetFloat("_Lacunarity", lacunarity[index]);
            renderer2D.material.SetFloat("_Persistence", persistence[index]);
            renderer2D.material.SetVector("_NoiseOffset", noiseOffset[index]);
            renderer2D.material.SetFloat("_Contribution", contribution[index]);
            renderer2D.material.SetFloat("_Normalize", normalize[index]);
            renderer2D.material.SetFloat("_AnimSpeed", animSpeed[index]);
            renderer2D.material.SetFloat("_CellType", cellType[index]);
            renderer2D.material.SetFloat("_DistanceFunction", distanceFunction[index]);
            renderer2D.material.SetVector("_RangeClamp", rangeClamp[index]);
            renderer2D.material.SetFloat("_Floor", floor[index]);
            renderer2D.material.SetFloat("_Powered", powered[index]);
            renderer2D.material.SetFloat("_RidgePower", ridgePower[index]);
            renderer2D.material.SetFloat("_BillowPower", billowPower[index]);
            renderer2D.material.SetFloat("_RidgeOffset", ridgeOffset[index]);
            renderer2D.material.SetFloat("_Warp", warp[index]);
            renderer2D.material.SetFloat("_Warp0", warp0[index]);
            renderer2D.material.SetFloat("_Damp", damp[index]);
            renderer2D.material.SetFloat("_Damp0", damp0[index]);
            renderer2D.material.SetFloat("_DampScale", dampScale[index]);
            renderer2D.material.SetFloat("_RadiusLow", radiusLow[index]);
            renderer2D.material.SetFloat("_RadiusHigh", radiusHigh[index]);
            renderer2D.material.SetFloat("_Radius", radius[index]);
            renderer2D.material.SetFloat("_MaxDimness", maxDimness[index]);
            renderer2D.material.SetFloat("_Probability", probability[index]);
        }
        else
        {
            if (windows) renderer3D.material.SetFloat("_Octaves", octaves[index]);
            renderer3D.material.SetFloat("_Frequency", frequency[index]);
            renderer3D.material.SetFloat("_Amplitude", amplitude[index]);
            renderer3D.material.SetFloat("_Lacunarity", lacunarity[index]);
            renderer3D.material.SetFloat("_Persistence", persistence[index]);
            renderer3D.material.SetVector("_NoiseOffset", noiseOffset[index]);
            renderer3D.material.SetFloat("_Contribution", contribution[index]);
            renderer3D.material.SetFloat("_Normalize", normalize[index]);
            renderer3D.material.SetFloat("_AnimSpeed", animSpeed[index]);
            renderer3D.material.SetFloat("_CellType", cellType[index]);
            renderer3D.material.SetFloat("_DistanceFunction", distanceFunction[index]);
            renderer3D.material.SetVector("_RangeClamp", rangeClamp[index]);
            renderer3D.material.SetFloat("_Floor", floor[index]);
            renderer3D.material.SetFloat("_Powered", powered[index]);
            renderer3D.material.SetFloat("_RidgePower", ridgePower[index]);
            renderer3D.material.SetFloat("_BillowPower", billowPower[index]);
            renderer3D.material.SetFloat("_RidgeOffset", ridgeOffset[index]);
            renderer3D.material.SetFloat("_Warp", warp[index]);
            renderer3D.material.SetFloat("_Warp0", warp0[index]);
            renderer3D.material.SetFloat("_Damp", damp[index]);
            renderer3D.material.SetFloat("_Damp0", damp0[index]);
            renderer3D.material.SetFloat("_DampScale", dampScale[index]);
            renderer3D.material.SetFloat("_RadiusLow", radiusLow[index]);
            renderer3D.material.SetFloat("_RadiusHigh", radiusHigh[index]);
            renderer3D.material.SetFloat("_Radius", radius[index]);
            renderer3D.material.SetFloat("_MaxDimness", maxDimness[index]);
            renderer3D.material.SetFloat("_Probability", probability[index]);
        }
    }
    #endregion

    void UpdateTexturing()
    {
        if (displace)
        {
            renderer3D.material.SetFloat("_Displace", 1.0f);
            if (texturing)
            {
                renderer3D.material.SetFloat("_Texturing", 1.0f);
                renderer3D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer3D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
            }
        }
        else
        {
            if (texturing)
            {
                renderer2D.material.SetFloat("_Texturing", 1.0f);
                renderer2D.material.SetTexture("_LowTexture", textures[selectedItemIndexTextureLow]);
                renderer2D.material.SetTexture("_HighTexture", textures[selectedItemIndexTextureHigh]);
            }
        }
    }
}
