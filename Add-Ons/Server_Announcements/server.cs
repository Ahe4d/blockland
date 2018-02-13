if(isFile("Add-Ons/System_ReturnToBlockland/server.cs"))
{
	if(!$RTB::RTBR_ServerControl_Hook)
		exec("Add-Ons/System_ReturnToBlockland/RTBR_ServerControl_Hook.cs");
	if(!$Pref::Server::AnnounceEnabled)
    {
        $Pref::Server::AnnounceEnabled = true;
    }
	if(!$Pref::Server::AnnouncePrivs)
    {
        $Pref::Server::AnnouncePrivs = 2;
    }
	if(!$Pref::Server::AnnounceWhitelist)
    {
        $Pref::Server::AnnounceWhitelist = "0";
    }
    RTB_registerPref("Enabled?","Announcement Mod","$Pref::Server::AnnounceEnabled","bool","Server_Announcements",$Pref::Server::AnnounceEnabled,0,1);
	RTB_registerPref("Privileges","Announcement Mod","$Pref::Server::AnnouncePrivs","list Player 0 Admin 1 SuperAdmin 2 Host 3 Whitelist 4 None 5","Server_Announcements",$Pref::Server::AnnouncePrivs,0,1);
	RTB_registerPref("Whitelist BLIDs", "Announcement Mod","$Pref::Server::AnnounceWhitelist","string 255","Server_Announcements",$Pref::Server::AnnounceWhitelist,0,1);
}
else if($Pref::Server::AnnounceEnabled $= "")
{
	$Pref::Server::AnnounceEnabled = true;
	$Pref::Server::AnnouncePrivs = 2;
	$Pref::Server::AnnounceWhitelist = "0";
}
//$var = "Ahead";
//for(%i=0;%i < getWordCount($var);%i++) {
//   %word = getWord($var, %i);
//   %name = %client.name;
//   %int = striPos(%name, %word);
//   if(%int != -1)
//	   echo("yep. he gay!");
//   else
//	   echo("yep. he not gay!");
//}


function checkBL_ID(%client) {
	$blidsuccess = 2;
    for(%i=0;%i<getWordCount($Pref::Server::AnnounceWhitelist);%i++) {
        if(atoi(getWord($Pref::Server::AnnounceWhitelist, %i)) == %client.getBLID()) return $blidsuccess = 1;
    }
    return $blidsuccess = 0;
}
function ServerCMDAnnounce(%client, %Chat, %Chat2, %Chat3, %Chat4, %Chat5, %Chat6, %Chat7, %Chat8, %Chat9, %Chat10, %Chat11, %Chat12, %Chat13, %Chat14, %Chat15, %Chat16, %Chat17)
{
    // Check if mod is enabled
    if ($Pref::Server::AnnounceEnabled == true)
	{
		// Enabled
        // Check Priv Level
        if ($Pref::Server::AnnouncePrivs == 0)
	    {
		    // Anyone
            %count = ClientGroup.getCount();
		    for(%cl = 0; %cl < %count; %cl++)
		    {
		    	%clientB = ClientGroup.getObject(%cl);
		    	%clientB.bottomPrint(%chat SPC %chat2 SPC %chat3 SPC %chat4 SPC %chat5 SPC %chat6 SPC %chat7 SPC %chat8 SPC %chat9 SPC %chat10 SPC %chat11 SPC %chat12 SPC %chat13 SPC %chat14 SPC %chat15 SPC %chat16,10);
		    }
	    }
        else if ($Pref::Server::AnnouncePrivs == 1)
	    {
		    // Admin
           if (%client.isAdmin == true)
	        {
		        // Is Admin
                %count = ClientGroup.getCount();
		        for(%cl = 0; %cl < %count; %cl++)
		        {
		        	%clientB = ClientGroup.getObject(%cl);
		        	%clientB.bottomPrint(%chat SPC %chat2 SPC %chat3 SPC %chat4 SPC %chat5 SPC %chat6 SPC %chat7 SPC %chat8 SPC %chat9 SPC %chat10 SPC %chat11 SPC %chat12 SPC %chat13 SPC %chat14 SPC %chat15 SPC %chat16,10);
		        }
	        }
            else
        	{
                // Not Admin
                messageClient(%client,'',"\c1You are not Admin.");
	        }
	    }
        else if ($Pref::Server::AnnouncePrivs == 2)
	    {
		    // Super Admin
           if (%client.isSuperAdmin == true)
	        {
		        // Is SA
                %count = ClientGroup.getCount();
		        for(%cl = 0; %cl < %count; %cl++)
		        {
		        	%clientB = ClientGroup.getObject(%cl);
		        	%clientB.bottomPrint(%chat SPC %chat2 SPC %chat3 SPC %chat4 SPC %chat5 SPC %chat6 SPC %chat7 SPC %chat8 SPC %chat9 SPC %chat10 SPC %chat11 SPC %chat12 SPC %chat13 SPC %chat14 SPC %chat15 SPC %chat16,10);
		        }
	        }
            else
        	{
                // Not SA
                messageClient(%client,'',"\c1You are not Super Admin.");
	        }
	    }
        else if ($Pref::Server::AnnouncePrivs == 3)
	    {
		    // Host
            if (%client.bl_id == getNumKeyID() && $client.isSuperAdmin == true)
	        {
		        // Is Host
                %count = ClientGroup.getCount();
		        for(%cl = 0; %cl < %count; %cl++)
		        {
		        	%clientB = ClientGroup.getObject(%cl);
		        	%clientB.bottomPrint(%chat SPC %chat2 SPC %chat3 SPC %chat4 SPC %chat5 SPC %chat6 SPC %chat7 SPC %chat8 SPC %chat9 SPC %chat10 SPC %chat11 SPC %chat12 SPC %chat13 SPC %chat14 SPC %chat15 SPC %chat16,10);
		        }
	        }
            else
        	{
                // Not Host
                messageClient(%client,'',"\c1You are not the host.");
	        }
	    }
		else if ($Pref::Server::AnnouncePrivs == 4)
		{
			checkBL_ID(%client);
			if ($blidsuccess != 0) {
				%count = ClientGroup.getCount();
		        for(%cl = 0; %cl < %count; %cl++)
		        {
		        	%clientB = ClientGroup.getObject(%cl);
		        	%clientB.bottomPrint(%chat SPC %chat2 SPC %chat3 SPC %chat4 SPC %chat5 SPC %chat6 SPC %chat7 SPC %chat8 SPC %chat9 SPC %chat10 SPC %chat11 SPC %chat12 SPC %chat13 SPC %chat14 SPC %chat15 SPC %chat16,10);
		        }
			} else if ($blidsuccess != 1) {
				// BLID does not match
				messageClient(%client,'',"\c1You are not on the whitelist of BLIDs who can use \c3/announce\c1. Ask the host to add your BLID to the list.");
			}
		}
        else if ($Pref::Server::AnnouncePrivs == 5)
	    {
		    // No-one
            messageClient(%client,'',"\c1Nobody is allowed to use \c3/announce\c1. Ask the host to change the privilege level.");
	    }
		
	}
    else
	{
        // Disabled
        messageClient(%client,'',"\c3/announce \c1has been disabled. Ask the host to enable it.");
	}
}