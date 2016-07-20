using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
public class PingController
{
    [HttpGet("api/ping")]
    public object Ping(){
        return  DateTime.UtcNow;
    }
}