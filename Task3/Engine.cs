using System;

namespace Task3
{
    public class Engine
    {
        private EngineType _engineType;
        private float _oilLevel = 1;

        public Engine(EngineType engineType)
        {
            _engineType = engineType;
        }
        public enum EngineType
        {
            Diesel,
            Electric
        }
    }
    
}