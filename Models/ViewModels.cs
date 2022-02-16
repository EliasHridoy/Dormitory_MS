

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DomMS.Models
{
    public class ResultVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class BookingsVM
    {
        public long BookingId { get; set; }
        public string RoomName { get; set; }
        public string Date { get; set; }
        public string TimeDuration { get; set; }
    }
    public static class SessionName
    {       
        public static string Id { get; } = "Id";
        public static string mail { get; } = "email";
        public static string name { get; } = "name";
        public static string imgUrl { get; } = "imgUrl";
        public static string Role { get; set; } = "Role";
    }    
    public class FreeRoomSuggestionVM
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string RoomName { get; set; }
    }
}
