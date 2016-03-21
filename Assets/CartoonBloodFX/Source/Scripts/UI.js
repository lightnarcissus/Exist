public var particleSpanwner:GameObject[];
public var indexSpawn:int = 0;
public var epictime:boolean;
public var ground:Transform;
private var timetemp = 0;
private var count = 0;


function Start(){
	timetemp = Time.time;
}
function Update () {
	this.transform.RotateAround(Vector3.up,Time.deltaTime * 0.2f);

	if(Input.GetButtonDown("Fire1"))
	{
    	var ray = GameObject.Find("Main Camera").camera.ScreenPointToRay (Input.mousePosition);
   		var hit : RaycastHit;
   		
    	if (Physics.Raycast (ray, hit, 100)) {
    	if(hit.transform.tag == "ground"){
       		if(particleSpanwner.Length>0){
       			SpawnParticle(hit.point);
            }
   		}
   		}

	}
	if(epictime){
	if(Time.time>timetemp+0.7){
		timetemp = Time.time;
		SpawnParticle(new Vector3(Random.Range(-30,30),0,Random.Range(-30,30)));
		indexSpawn = Random.Range(0,particleSpanwner.Length);
	}
	}
}


function SpawnParticle(position:Vector3){
	var offset:Vector3 = Vector3.zero;
	
	if(particleSpanwner[indexSpawn].GetComponent(ParticleSetting)){
       offset = particleSpanwner[indexSpawn].GetComponent(ParticleSetting).PositionOffset;
    }
    
    var particle:GameObject = GameObject.Instantiate(particleSpanwner[indexSpawn], position + offset, Quaternion.identity);   	
}





function OnGUI(){
	if(particleSpanwner.Length>0){
	if(GUI.Button(new Rect(10,10,150,30),"Prev")){
		indexSpawn--;
		if(indexSpawn<0){
			indexSpawn = particleSpanwner.Length-1;
		}
	}
	GUI.Label(new Rect(10,40,1000,30),"Particle Name: "+particleSpanwner[indexSpawn].name.ToString());
	if(GUI.Button(new Rect(170,10,150,30),"Next")){
		indexSpawn++;
		if(indexSpawn>=particleSpanwner.Length){
			indexSpawn = 0;
		}
	}
	
	if(GUI.Button(new Rect(350,10,120,30),"Ground")){
		if(ground.gameObject.renderer.enabled){
			ground.gameObject.renderer.enabled = false;
		}else{
			ground.gameObject.renderer.enabled = true;
		}
	}
	
	if(GUI.Button(new Rect(480,10,120,30),"Show time")){
		if(epictime){
			epictime = false;
		}else{
			epictime = true;
		}
	}
	}
	
}