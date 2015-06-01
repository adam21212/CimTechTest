﻿
namespace TechTestCTM.Business
{
    public interface IFactory<T> where T : class
    {
        T Create();
    }
}
