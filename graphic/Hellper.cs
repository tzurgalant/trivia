using System;
using System.Net.Sockets;

namespace clientGraphic
{
    public enum CodeR : byte
    {
        LoginCmd = 100,
        SignupCmd,              // 101
        ErrorCmd,               // 102
        LogoutCmd,              // 103
        GetRoomsCmd,            // 104
        GetPlayersInRoomCmd,    // 105
        GetPersonalStatsCmd,    // 106
        JoinRoomCmd,            // 107
        CreateRoomCmd,          // 108
        GetHighScoreCmd         // 109
    }
    public struct UserInfo
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public bool IsLogged { get; set; }

    }
    internal static class Helper
    {
        public static UserInfo _currentUser;
        //public static bool IsUserLogged()/// in the fetuher wiil check whit the server... 
        //{

        //    return _currentUser.IsLogged;
        //}
        //public static void setUserLoggedSatate(bool state)/// in the fetuher wiil check whit the server... 
        //{
        //    _currentUser.IsLogged = state;
        //}

        public static void HideLabelAfterDelay(Label targetLabel, int delayMs = 3000)
        {
            targetLabel.Visible = true;

            System.Windows.Forms.Timer alertTimer = new System.Windows.Forms.Timer(); alertTimer.Interval = delayMs; 

            alertTimer.Tick += (s, args) =>
            {
                targetLabel.Visible = false; // מכבה את הלייבל הספציפי שקיבלנו!
                alertTimer.Stop();
                alertTimer.Dispose();
            };

            alertTimer.Start();
        }
    }
}


