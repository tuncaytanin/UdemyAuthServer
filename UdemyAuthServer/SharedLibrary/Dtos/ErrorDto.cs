using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class ErrorDto
    {
        public List<String> Erros { get; private set; }  = new List<String>();
        public bool IsShow { get; private set; }

        public ErrorDto(string error,bool isShow)
        {
            Erros.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<String> erros, bool isShow)
        {
            Erros = erros;
            IsShow = isShow;
        }
    }
}
