﻿namespace Luttra.XIdentity.BusinessLogic.Helpers
{
    public static class ViewHelpers
    {
        public static string GetClientName(string clientId, string clientName)
        {
            return $"{clientId} ({clientName})";
        }
    }
}
