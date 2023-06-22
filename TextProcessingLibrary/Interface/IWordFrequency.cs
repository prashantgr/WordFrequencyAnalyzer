using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessingLibrary.Interface
{
    public interface IWordFrequency
    {
        int Frequency { get; set; }
        string Word { get; set; }
    }
}
