//---------------------------------------------------
// Toggle Suicide
// Allows admins to toggle on and off player suicide
// by Ahead (ID: 33159)
//
// "Heroes never di- oh wait, they can't die anyway."
//---------------------------------------------------

package ToggleSuicide
{
    //function cooldown()
    //{
    //    if(!%client.cooldown)
    //        return;
    //    %client.cooldown = 0;
    //}

    function serverCmdToggleSuicide(%client)
    {
        if(!%client.isAdmin) //let's check if they're admin
            return; //if they're not, return the entire thing.

        //schedule(0, 5000, cooldown, %client); // i win. horrible code!!!!
        if($suicide == 1) //is suicide on?
        {
            messageAll('MsgAdminForce',"\c4" @ %client.getPlayerName() SPC "\c6has toggled suicide \c0off. \c6Nobody can suicide anymore."); //\c4 is cyan \c6 is white
            return $suicide = 0; //let's turn it off.
        }
        else //what if it's not on?
        {
            messageAll('MsgAdminForce',"\c4" @ %client.getPlayerName() SPC "\c6has toggled suicide \c2on. \c6Anyone can now suicide at any time.");
            return $suicide = 1; //let's turn it on.
        }

    }
    function serverCmdSuicide(%client)
    {
        if($suicide)
            parent::serverCmdSuicide(%client); //this makes it so the old code is still there.
        else
            return messageClient(%client,'',"\c6Suicide has been turned \c0off. \c6Please wait until an admin does \c4/toggleSuicide, \c6and then you will be able to suicide again.");
    }
};
activatePackage(ToggleSuicide);

//function servercmdCoolDown(%client,%time)
//{
//    if(getSimTime() - %client.lastCooldown <= %time) //if current time subtracted by saved time is less than %time in ms
//    {
//        %client.chatmessage("\c6Please wait "@ %time - (getSimTime() - %client.lastcoolDown) "before you can use /toggleSuicide again."); //calculates time remaining, Time - DifferenceInTime
//        return;
//    }
//    %client.chatMessage("\c6Successfully cooldowned. You may now use /toggleSuicide again.");
//    %client.lastCooldown = getSimTime();
//}