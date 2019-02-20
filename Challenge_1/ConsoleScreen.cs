using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public interface ConsoleScreen
    {
        void Draw();
        void OnKeyPress(ConsoleKeyInfo key);
        void Run();
    }
}
