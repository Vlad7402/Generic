using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsAutomat
{
    public enum Colors
    {
        Yellow, Red, Black, Gray
    }
    public enum Errors
    {
        VocabulararyError, SaveError, WordIsInVocabularyError, WordIsOutError, InProcess
    }
    public enum Asic
    {
        X, Y, Aditional, Uncorrect
    }
    public enum Move
    {
        Up = 1, Down = -1, Uncorrect
    }
    public enum ReaderType
    {
        Keyboard, Mouse
    }
}
