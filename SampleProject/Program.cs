﻿using System;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //using autogenerated codes
            LoginCommand_1 cmd = new LoginCommand_1(Guid.NewGuid(), "admin", "admin");
            var handler=new LoginCommandHandler();
            var result = handler.Handle(cmd);
        }
    }
}
