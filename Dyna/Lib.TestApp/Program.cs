using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lib.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string application = Assembly.GetExecutingAssembly().GetName().Name;
            string solutionPath = path.Split(new string[] { application }, StringSplitOptions.RemoveEmptyEntries)[0];
            string dynamoAssm = string.Concat(solutionPath,"Dynamo.lib\\bin\\Debug\\Dynamo.lib.dll");
            Assembly assm = Assembly.LoadFile(dynamoAssm);

            object e = assm.CreateInstance("Dynamo.lib.Element");
            Type dynamoLib = e.GetType();
            ConstructorInfo dynamoLibConstructor = dynamoLib.GetConstructor(Type.EmptyTypes);

            object dynamoClsObj = dynamoLibConstructor.Invoke(new object[] { });


            object dynamoVal = dynamoLib.GetMethod("PickElement").Invoke(dynamoClsObj, null);

            Console.Write(AppDomain.CurrentDomain.BaseDirectory);
            //Assembly assm = Assembly.LoadFile("");
        }
    }
}
