if(isFile("Add-Ons/System_BlocklandGlass/server.cs")) {
	function serverCmdSetRank(%cl, %blid, %letter, %color) {
		if(%cl.isAdmin)
			commandToAll('Glass_setPlayerlistStatus', %blid, %letter, %color);
	}
}

//see that wasn't so hard................... lol
