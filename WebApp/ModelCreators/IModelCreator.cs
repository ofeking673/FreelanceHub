using System.Data;
using AlexProject.Models;

namespace WebApplication2.ModelCreators
{
    public interface IModelCreator<T>
    {
        public static T CreateModel(IDataReader src) { return default(T); }
    }
}
