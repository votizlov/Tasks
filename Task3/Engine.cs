using System;

namespace Task3
{
    public abstract class Engine
    {
        private String EngineType;

        Engine(String engineType)
        {
            EngineType = engineType;
        }
    }
}