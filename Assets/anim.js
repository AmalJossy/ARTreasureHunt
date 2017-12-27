var ani : Animation;
 
function Start () {
    ani.enabled = false;
}
 
function OnMouseDown () {
    ani.enabled = true;
    {
        yield WaitForSeconds (2);
        ani.enabled = false;
    }   
}