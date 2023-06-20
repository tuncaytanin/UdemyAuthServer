using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public  class Response<T> where T:class
    {

        public T Data { get; set; }

        [JsonIgnore]
        public int SatusCode { get;private set; }

        [JsonIgnore]
        public bool IsSuccess { get; private set; } 


        public ErrorDto Error { get; set; }
        public static Response<T> Success(T data,int  satusCode)
        {
            return new Response<T> { Data = data, SatusCode = satusCode ,IsSuccess=true};
        }

        public static Response<T> Success(int satusCode)
        {

            return new Response<T> { Data=null, SatusCode = satusCode, IsSuccess = true };
        }


        public static Response<T> Fail(ErrorDto errorDto, int satusCode ) {

            return new Response<T>
            {
                Error = errorDto,
                SatusCode = satusCode,
                IsSuccess = false
            };
        }
        public static Response<T> Fail(string errorMessage, int satusCode,bool isShowErrorMessage)
        {
            var errorDto = new ErrorDto(errorMessage, isShowErrorMessage);
            return new Response<T>
            {
                Error = errorDto,
                SatusCode = satusCode,
                IsSuccess = false
            };
        }
    }
}
