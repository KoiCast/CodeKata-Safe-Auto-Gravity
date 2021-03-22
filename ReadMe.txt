The UI code is stored in 'web' and the api stored in 'GravityCodeChallenge'. The UI is written in angular and should require only a quick npm install and ng serve.



See the example input and output provided below:

Example input:  
Driver Dan  
Driver Alex  
Driver Bob  
Trip Dan 07:15 07:45 17.3  
Trip Dan 06:12 06:32 21.8  
Trip Alex 12:01 13:16 42.0  

Expected output:  
Alex: 42 miles @ 34 mph  
Dan: 39 miles @ 47 mph  
Bob: 0 miles 

The average mph in the example output for Dan seems to be incorrect. 

Dan has two trips 17.3 miles in .5hrs (34.6 mph) and 21.8 miles in 1/3hr (65.4 mph). Average mph for this would be 50mph.

There is a request to round miles and mph but it does not indicate when to round these however as the request to round immediately follows directions about formatting the output I assumed the rounding applied to the output only.
