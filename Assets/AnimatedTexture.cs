using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
 
	//vars for the whole sheet
public int colCount =  2;
public int rowCount =  1;
 
//vars for animation
public int  rowNumber  =  0; //Zero Indexed
public int colNumber = 0; //Zero Indexed
public int totalCells = 2;
public static int  fps     = 5;
  //Maybe this should be a private var
    private Vector2 offset;
	
	void Start()
	{
		SetSpriteAnimation(colCount,rowCount,rowNumber,colNumber,totalCells,fps);
	}
//Update
void Update () { SetSpriteAnimation(colCount,rowCount,rowNumber,colNumber,totalCells,fps);  }
 
//SetSpriteAnimation
void SetSpriteAnimation(int colCount ,int rowCount ,int rowNumber ,int colNumber,int totalCells,int fps ){
 var uIndex=0;
    // Calculate index
    int index  = (int)((Time.time%0.5f) * fps); 
    // Repeat when exhausting all cells
    index = index % totalCells;
 
    // Size of every cell
    float sizeX = 1.0f / colCount;
    float sizeY = 1.0f / rowCount;
    Vector2 size =  new Vector2(sizeX,sizeY);
 
    // split into horizontal and vertical index
    uIndex= index % colCount;
    var vIndex = index / colCount;
 
    // build offset
    // v coordinate is the bottom of the image in opengl so we need to invert.
    float offsetX = (uIndex+colNumber) * size.x;
    float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
    Vector2 offset = new Vector2(offsetX,offsetY);
 
    renderer.material.SetTextureOffset ("_MainTex", offset);
    renderer.material.SetTextureScale  ("_MainTex", size);
}
}