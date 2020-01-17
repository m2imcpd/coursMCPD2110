using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionBataille.Classes
{
    public interface IJoueur
    {
        List<Carte> Cartes { get; set; }
    }
}
