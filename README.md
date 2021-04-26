# MongoDB with Unity

The repo is a step by step procedure to understand how you can save data from your Unity game to a MongoDB VM that is set up online, i.e. not a local DB on your own computer.
This set up has been tested with mainly WebGL in mind, and therefore works for WebGL files you might be serving through MongoDB/Github/Any other service.

## In Unity:

In playerData.cs :

We first set up a cs script that initializes the data you want to save. Under playerData.cs, two instances are being saved here, 
a string called tag, and the position of a player as a float[]

You will, of course, have to edit the webhook address in playerData.cs to reflect your own webhook.

## In the script that collects data
eg. FirstPersonController.cs
If we need this data to be updated every 2 seconds, we call an InvokeRepeating function that collects and sends this data every 2 secs.
Further, we are collecting the 'tag' data from a Canvas 'canv' with a function called GetInputOnClick and extracting the text from it.
You can modify this to be something else, of course.
We are then calling the IEnumerator 'SavePlayerData' that we set up in 'playerData.cs'

## MongoDB
This part onwards is on your MongoDB VM (Atlas and Realm) that you already must have in place. A free tier VM that collects up to
512MB is available for everyone.

We're saving this data on Atlas (which is already connected to Realm) under scoreDB in scoreCollection. The script 'realmfunc' goes into
the Realm Webhook Function Editor, i.e. App>3rd Party Services>Service Name>Incoming Webhook>Function Editor
Make sure that the HTTP method in the Settings reflects what you are trying to do. In this case, I am "POST"ing information, hence 
the HTTP method is set to POST.

'info' in this context is your collection of information that you want saved on Realm. In our case, this is the 'tag' and 'position3D'
that we defined in our 'playerData.cs'

# Credits:
Most of this information is available in a more detailed form in the series of videos and blogs by MongoDB devs Adrienne Tacke,
Nic Raboy and Karen Huaulme (special thanks to Karen for advocating the use of Realm Webhooks in the series).
The blogs can be found through here:
https://developer.mongodb.com/how-to/designing-strategy-develop-game-unity-mongodb/
