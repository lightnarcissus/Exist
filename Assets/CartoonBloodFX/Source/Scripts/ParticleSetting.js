var LightIntensityMult:float = -0.5f;
var LifeTime:float = 1;
var RandomRotation:boolean = false;
var PositionOffset:Vector3;
var SpawnEnd:GameObject;
var Scale:float = 1;
private var timetemp;
function Start(){
	timetemp = Time.time;
	if(RandomRotation){
		this.gameObject.transform.rotation.x = Random.rotation.x;
		this.gameObject.transform.rotation.y = Random.rotation.y;
		this.gameObject.transform.rotation.z = Random.rotation.z;
	}
	
	SetScale(this.transform);	
	for(var child : Transform in this.transform){
   		SetScale(child);
	}
}
function Update () {
	if(Time.time > timetemp + LifeTime){
		if(SpawnEnd){
			var obj = GameObject.Instantiate(SpawnEnd,this.transform.position,this.transform.rotation);
		}
		GameObject.Destroy(this.gameObject);
	}
	if(this.gameObject.light){
		this.light.intensity += LightIntensityMult * Time.deltaTime;
	}
}


function SetScale(obj:Transform){
	 obj.localScale *= Scale;
	
	 if(obj.gameObject.GetComponent(Light)){
		 obj.gameObject.GetComponent(Light).range *= Scale;
	 }
	
	 if(obj.GetComponent(ParticleSystem)){
	 	var particle:ParticleSystem = obj.GetComponent(ParticleSystem);
		particle.startSpeed *= Scale;
		particle.startSize *= Scale;
		particle.gravityModifier *= Scale;
		
	 }
}