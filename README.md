<pre>
# HepsiBurada.Rover.API

<b>Technologies:</b> .Net Core 3.1
<b>API url:</b> 
{Scheme}://{ServiceHost}:{ServicePort}/rover

<b>API Methods: </b>
RoverController.GetRoverStatus(RoverRequest)
<b>Url:</b> {Scheme}://{ServiceHost}:{ServicePort}/rover
<b>Type:</b> Post

<b>Request:</b>
{
   "AreaLength" : 
   {
      "X": int, // X coordinate of plateau area
      "Y": int  // Y coordinate of plateau area
   },
   "StartingCoordinates": 
   {  
       "X": int, // X position of rover
       "Y": int  // Y position of rover
   },
   "StartingDirection": string,  // Direction of rover(W, E, N, S)
   "Mapping": string   // rover moves in string(L, R, M)
}

<b>Response:</b>
{
   "status": int,   // 1 = ok, -1 error
   "message": string,   // if status -1 then message gives explanation about error
   "errorCode": string,   // if status -1 then errorCode gives HResult code about error
   "data":   // if status 1 then gives response data
   {
      "finalX": int,   // final X cordinate of rover
      "finalY": int,   // final Y cordinate of rover
      "finalDirection": string   // final direction of rover
   }
}


<b>Example:</b>
<b>Request:</b>
{
   "AreaLength": 
   {
      "X": 5,
      "Y": 5
   },
   "StartingCoordinates": 
   {
      "X": 3,
      "Y": 3
   },
   "StartingDirection": "E",
   "Mapping": "MMRMMRMRRM"
}
   
<b>Response:</b>
{
   "status": 1,
    "message": null,
    "errorCode": null,
    "data": 
    {
       "finalX": 5, 
       "finalY": 1, 
       "finalDirection": "E" 
    }
}
</pre>
