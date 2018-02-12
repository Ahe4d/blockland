//------------------------------------
// Ahead Client Tools
// Module loading system
// by Ahead (ID: 33159)
//------------------------------------

echo("Ahead Client Tools | Loading main functions");
function loadAheadModules() //function for finding & loading modules; basically it's just loadClientAddOns
{
	%dir = "Add-Ons/Client_Ahead/Modules/*/module.cs";
	%fileCount = getFileCount(%dir);
	%filename = findFirstFile(%dir);
	%dirCount = 0;
	while(%filename !$= "")
	{
		%path = filePath(%filename);
		%dirName = getSubStr(%path, strlen("Add-Ons/Client_Ahead/Modules/"), strlen(%path) - strlen("Add-Ons/Client_Ahead/Modules/"));
		%dirNameList[%dirCount] = %dirName;
		%dirCount = %dirCount + 1.0;
		%filename = findNextFile(%dir);
	}
	%i = 0;
	while(%i < %dirCount)
	{
		%dirName = %dirNameList[%i];
		echo("Ahead Client Tools | Client checking module: " @ %dirName);
		%name = %dirName;
		echo("Ahead Client Tools | Loading module: " @ %dirName);
		exec("Add-Ons/Client_Ahead/Modules/" @ %dirName @ "/module.cs");
		%i = %i + 1.0;
	}
}
echo("Ahead Client Tools | Looking for modules");
loadAheadModules();
echo("Ahead Client Tools | Done!");
