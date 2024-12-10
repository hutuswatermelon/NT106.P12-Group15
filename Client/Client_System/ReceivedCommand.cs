using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_System
{
    public enum ServerCommand
    {
        SignInFailed,
        SIF_AccountUsing,
        SignInSuccess,
        SignUpFailed,
        SignUpSuccess,
        ChangePasswordSuccess,
        UpdateLobbyforNewJoining,
        UpdatePlayerinRoom,
        ChatMessage,
        EndStory,
        StartRoom,
        BecomeMaster,
        NewMaster,
        UpdateLobby,
        UpdateSettings,
        UpdateMaxPlayer,
        TimeOut,
        NextRound,
        EndRoom,
        Unknown
    }
}
