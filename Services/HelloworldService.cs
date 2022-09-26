using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services;

public class HelloworldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World!";
    }

    public string GetHelloWorld2()
    {
        return "";
    }
}


public interface IHelloWorldService
{
    string GetHelloWorld();
}