.NET Client for the BandsInTown API

<a href="http://dkdevelopment.net/2010/04/29/smack-my-bitsharp/">http://dkdevelopment.net/2010/04/29/smack-my-bitsharp/</a>

Example usage:

	var client = new BitClient("API_KEY_HERE");
 
	//call the functions you want from the client
	Artist artist = null;
    try
    {
        artist = client.Artists_Get("de11b037-d880-40e0-8901-0397c768c457");
    }
    catch (BitException ex)
    {
        //BandsInTown returned an error
    }