using Script.UI.Buttons;
using UnityEngine.Networking.PlayerConnection;

namespace Script.Characters
{
    public class BotPlayer : Player
    {
        public BotPlayer(NextTurnButton nextTurnButton) : base(nextTurnButton)
        {
        }
    }
}