using System;

namespace Orponing.Data
{
    public class RepositoryExeption : Exception
    {
        public RepositoryExeption(string message) : base(message) { }
    }
}