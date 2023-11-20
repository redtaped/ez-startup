using System.Diagnostics;

namespace Logic
{
    public interface IWindowsPositioner
    {
        void Position(Process process, int positionX, int positionY, int sizeX, int sizeY);
    }
}