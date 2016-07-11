using System;
using Microsoft.AspNetCore.Mvc;

public class PingController
{
    [HttpGet("api/ping")]
    public object Ping(){
        return  DateTime.UtcNow;
    }
}