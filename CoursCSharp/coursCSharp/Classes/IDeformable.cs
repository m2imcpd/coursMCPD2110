using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public interface IDeformable
    {
        Figure Deformation(float coeffH, float coeffV);
    }
}
